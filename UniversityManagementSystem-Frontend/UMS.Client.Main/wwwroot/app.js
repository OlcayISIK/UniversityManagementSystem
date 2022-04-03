export function setScroll() {
    //let's fix scroll here
    var divMessageContainerBase = document.getElementById('divMessageContainerBase');
    if (divMessageContainerBase != null)
        divMessageContainerBase.scrollTop = divMessageContainerBase.scrollHeight;
}

export function getMessageInput() {
    var txtMessageInput = document.getElementById("txtMessageInput").value;
    document.getElementById("txtMessageInput").value = '';
    return txtMessageInput;
}