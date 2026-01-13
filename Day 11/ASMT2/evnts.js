//1
mybutton=document.getElementById('pay');
mydiv=document.getElementById('paymentSection');

function clickHandlerchild(){
    console.log('child event handled');
}
function clickHandlerparent(){
    console.log('parent event handled');
}
mybutton.addEventListener('click',clickHandlerchild);
mydiv.addEventListener('click',clickHandlerparent);

//2
mybutton1=document.getElementById('pay2');
mydiv=document.getElementById('paymentSection2');
function clickHandlerC(){
    console.log('child event handled');
}
function clickHandlerP(){
    console.log('parent event handled');
}
document.getElementById("pay2").addEventListener("click", clickHandlerC, true);
document.getElementById("paymentSection2").addEventListener("click", clickHandlerP, true);

//3

function openPolicy(event){
    console.log('Policy Opened !');
}
function deletePolicy(event){
    event.stopPropagation();
    console.log('Button Deleted !');

}

//4

claimRow=document.querySelectorAll('.claimRow');
claimRow.forEach((i)=>{
i.addEventListener('click',(j)=>{
    console.log(i.querySelector('.claimInfo').innerText);
})

});

approvebtn=document.querySelectorAll('.approveBtn');
approvebtn.forEach((i)=>{
i.addEventListener('click',(j)=>{
   console.log('Approved!!');
   j.stopPropagation();
})
});



