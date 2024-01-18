mergeInto(LibraryManager.library, {
	Hello: function () {
    var messageString = "Hello!! postmessage test!";
    window.postMessage(messageString, "*");
    //window.alert("Hello, world!");
  },
});