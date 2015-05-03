var selector = document.body;

$(selector).on('click', '#upload-file-button', function() {
	$('#picture').click();
});

$(selector).on('change', '#picture', function() {
	var file = this.files[0],
		reader;
	
	if (file.type.match(/image\/.*/)) {
		reader = new FileReader();
		reader.onload = function() {
			$('.picture-name').text(file.name);
			$('.picture-preview').attr('src', reader.result);
			$('#picture').attr('data-picture-data', reader.result);
		};
		reader.readAsDataURL(file);
	} else {
		//Noty.error("Invalid file format.");
		console.log('invalid format');
	}
});