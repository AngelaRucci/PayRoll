pragma solidity ^0.4.0;
contract PayRoll{
    //array storing employees addresses
    address[] employees= [];
    uint totalETH = 0; 
    mapping(address => uint) ammountWithdrawn; 
    
    // Constructor function
    function PayRoll() public payable{
        updatedTotalETH();
    }
    //fallback function
    function () public payable{
        updatedTotalETH();
    }
    
    //updating total ETH to pay employees
    function updatedTotalETH() internal{
        totalETH += msg.value;
    }
    
    modifier canWithdrawl(){
        bool isEmployee = false;
        for(uint i=0; i< employees.length; i++){
            if(employees[i] == msg.sender){
                isEmployee = true;
            }
        }
        require(isEmployee);
        _;
    }
    
    function withdrawl() public canWithdrawl{
        uint payPerPerson = totalETH / employees.length;
        uint ammountWithdrawnForEmployee = ammountWithdrawn[msg.sender];
        uint pay = payPerPerson - ammountWithdrawnForEmployee;
        if(pay > 0){
            msg.sender.transfer(pay);
        }
    }
}
