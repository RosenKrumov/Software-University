<?php

namespace Core;


class App
{
    /*
     * @var Database
     */
    private $db;

    /*
     * @var User
     */
    private $user = null;

    /*
     * @var BuildingsRepository
     */
    private $buildingsRepository = null;

    public function __construct(Database $db){
        $this->db = $db;
    }

    public function isLogged(){
        return isset($_SESSION['id']);
    }

    /*
     * @param $username
     * @return bool
     */
    public function userExists($username){
        $result = $this->db->prepare('SELECT id FROM users WHERE username = ?');
        $result->execute([$username]);
        return $result->rowCount() > 0;
    }

    public function register($username, $password){
        if($this->userExists($username)){
            throw new \Exception("User already registered");
        }

        $result = $this->db->prepare("
            INSERT INTO users (username, password, gold, food)
            VALUES (?, ?, ?, ?);
        ");

        $result->execute(
            [
                $username,
                password_hash($password, PASSWORD_DEFAULT),
                User::GOLD_DEFAULT,
                User::FOOD_DEFAULT
            ]
        );
		
        if($result->rowCount() > 0){
            $userId = $this->db->lastId();

            $this->db->query("
                INSERT INTO players_buildings_levels (user_id, building_id, level_id)
                SELECT $userId, id, 0 FROM buildings
            ");

            return true;
        }

        throw new \Exception('Cannot register user');
    }

    public function login($username, $password){
        $result = $this->db->prepare("SELECT * FROM users WHERE username = ?");
        $result->execute([$username]);

        if($result->rowCount() == 0){
            throw new \Exception("Invalid username");
        }

        $user = $result->fetch();
        $password = password_verify($password, $user['password']);

        if($password){
            $_SESSION['id'] = $user['id'];
            $_SESSION['VerificationToken'] = uniqid();
            return new User($user['username'], $user['password'], $user['id'], $user['gold'], $user['food']);
        }

        throw new \Exception("Passwords do not match");
    }

    public function getUserInfo($id){
        $result = $this->db->prepare("
            SELECT
                *
            FROM
              users
            WHERE id = ?
        ");

        $result->execute([$id]);

        return $result->fetch();
    }

    /*
     * @return User|null
     */
    public function getUser(){
        if($this->user != null){
            return $this->user;
        }

        if($this->isLogged()){
            $user = $this->getUserInfo($_SESSION['id']);
            $this->user = $user = new User($user['username'], $user['password'], $user['id'], $user['gold'], $user['food']);
            return $this->user;
        }

        return null;
    }

    public function editUser(User $user){
        $result = $this->db->prepare("UPDATE users SET username = ?, password = ? WHERE id = ?");
        $result->execute([
            $user->getUsername(), $user->getPass(), $user->getId()
        ]);

        return $result->rowCount() > 0;
    }

    public function createBuildings(){
        if($this->buildingsRepository == null){
            $this->buildingsRepository = new BuildingsRepository($this->db, $this->getUser());
        }

        return $this->buildingsRepository;
    }
}