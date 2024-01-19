mergeInto(LibraryManager.library, {
	

  StartEyeDetection: function () {
    var messageString = "StartEyeDetection!! postmessage test!";
    window.postMessage(messageString, "*");
  },
});