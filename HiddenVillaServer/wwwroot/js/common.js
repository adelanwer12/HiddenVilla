window.ShowToastr = (type, message)=>{
    if (type === "success"){
        toastr.success(message, 'Operations Successful')
    }
    if (type === "error"){
        toastr.error(message, 'Operations Failed')
    }
}