function zulu_cms_openEditor(url) {
    window.open(url, "zulu_cms_editor", "width=850,height=600,scrollbars=1");
}

function zulu_cms_closeEditor() {
    window.opener.location.reload(true);
    window.close();
}