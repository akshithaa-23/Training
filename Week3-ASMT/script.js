const API = "https://696d0f0ef4a79b3151806b5a.mockapi.io/Banking";
let accountList = [];

//random balance (₹10,000 – ₹50,000)
function getRandomBalance() {
  return Math.floor(Math.random() * (50000 - 10000 + 1)) + 10000;
}

//TASK 9 localStorage 
function saveToStorage() {
  localStorage.setItem("bankAccounts", JSON.stringify(accountList));
}

function loadFromStorage() {
  const stored = localStorage.getItem("bankAccounts");
  return stored ? JSON.parse(stored) : null;
}

//TASK 10 total balance
function updateTotalBalance() {
  const total = accountList.reduce((sum, acc) => sum + Number(acc.balance), 0);

  const el = document.getElementById("totalBalance");
  if (el) el.innerText = `Total Bank Balance: ₹${total}`;
}

//Task 1
async function fetchAccounts() {
  try {
    // load from storage (Task 9)
    const storedAccounts = loadFromStorage();
    if (storedAccounts) {
      accountList = storedAccounts;
      loadBranchDropdown();
      displayAccounts(accountList);
      updateTotalBalance();
      return;
    }

    const res = await fetch(API);
    if (!res.ok) throw new Error("Network error");

    const data = await res.json();

    accountList = data.map(acc => ({
      id: acc.id,
      name: acc.name,
      email: acc.email,
      branch: acc.branch,
      balance: getRandomBalance(),
      transactions: [] 
    }));

    saveToStorage(); 

    loadBranchDropdown();
    displayAccounts(accountList);
    updateTotalBalance();
  } catch (error) {
    console.log("Error:", error.message);
  }
}

//Dispaly Accounts
function displayAccounts(list) {
  const container = document.getElementById("accounts");
  container.innerHTML = "";

  list.forEach(account => {
    const div = document.createElement("div");
    div.classList.add("card");

    // Task 10 highlight low balance
    if (Number(account.balance) < 5000) {
      div.style.border = "2px solid red";
      div.style.backgroundColor = "#ffe6e6";
    }

    div.innerHTML = `
      <h3>${account.name}</h3>
      <p><b>Account No:</b> ${account.id}</p>
      <p><b>Email:</b> ${account.email}</p>
      <p><b>Branch:</b> ${account.branch}</p>
      <p><b>Balance:</b> ₹${account.balance}</p>

      <button onclick="depositMoney('${account.id}')">Deposit</button>
      <button onclick="withdrawMoney('${account.id}')">Withdraw</button>
      <button onclick="deleteAccount('${account.id}')">Delete</button>
      <button onclick="viewHistory('${account.id}')">View History</button>
    `;

    container.appendChild(div);
  });
}

//Task 2 dropdown
function loadBranchDropdown() {
  const branchFilter = document.getElementById("branchFilter");
  branchFilter.innerHTML = `<option value="all">All Branches</option>`;

  const branches = [...new Set(accountList.map(acc => acc.branch))];

  branches.forEach(branch => {
    const option = document.createElement("option");
    option.value = branch;
    option.innerText = branch;
    branchFilter.appendChild(option);
  });
}

//search + filter
function applyFilters() {
  const searchValue = document.getElementById("searchInput").value.toLowerCase();
  const selectedBranch = document.getElementById("branchFilter").value;

  let filtered = accountList.filter(acc =>
    acc.name.toLowerCase().includes(searchValue)
  );

  if (selectedBranch !== "all") {
    filtered = filtered.filter(acc => acc.branch === selectedBranch);
  }

  displayAccounts(filtered);
}

document.getElementById("searchInput").addEventListener("input", applyFilters);
document.getElementById("branchFilter").addEventListener("change", applyFilters);

//Deposit
function depositMoney(id) {
  const amount = Number(prompt("Enter deposit amount:"));

  if (!amount || amount <= 0) {
    alert("Enter valid amount!");
    return;
  }

  const acc = accountList.find(a => a.id == id);

  acc.balance = Number(acc.balance) + amount;

  //Task 7 
  acc.transactions.push({
    type: "DEPOSIT",
    amount: amount,
    time: new Date().toLocaleString()
  });

  alert(`Deposited ₹${amount}`);

  saveToStorage();
  applyFilters();
  updateTotalBalance();
}

//Withdraw
function withdrawMoney(id) {
  const amount = Number(prompt("Enter withdrawal amount:"));

  if (!amount || amount <= 0) {
    alert("Enter valid amount!");
    return;
  }

  const acc = accountList.find(a => a.id == id);

  if (Number(acc.balance) < amount) {
    alert("Insufficient balance!");
    return;
  }
  acc.balance = Number(acc.balance) - amount;

  // Task 7 transaction record
  acc.transactions.push({
    type: "WITHDRAW",
    amount: amount,
    time: new Date().toLocaleString()
  });

  //Task 8
  if (acc.balance < 5000) {
    acc.balance = acc.balance - 200;

    acc.transactions.push({
      type: "PENALTY",
      amount: 200,
      time: new Date().toLocaleString()
    });

    alert("Balance below ₹5000. ₹200 penalty applied.");
  } else {
    alert(`Withdrawn ₹${amount}`);
  }

  saveToStorage();
  applyFilters();
  updateTotalBalance();
}

//Task 4 Create Acc
document.getElementById("createForm").addEventListener("submit", async function (e) {
  e.preventDefault();

  const name = document.getElementById("name").value.trim();
  const email = document.getElementById("email").value.trim();
  const branch = document.getElementById("branch").value.trim();

  if (!name || !email || !branch) {
    alert("Please fill all fields!");
    return;
  }

  const newAccount = { name, email, branch };

  try {
    const res = await fetch(API, {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(newAccount)
    });

    if (!res.ok) throw new Error("POST failed");

    const data = await res.json();

    accountList.push({
      id: data.id,
      name: data.name,
      email: data.email,
      branch: data.branch,
      balance: 10000,
      transactions: [] 
    });

    alert("Account Created!");

    saveToStorage();
    loadBranchDropdown();
    applyFilters();
    updateTotalBalance();

    e.target.reset();
  } catch (error) {
    console.log("Error creating account:", error.message);
    alert("Account not created!");
  }
});

//Task 5 Delete Acc
async function deleteAccount(id) {
  const ok = confirm("Are you sure you want to delete this account?");
  if (!ok) return;

  try {
    const res = await fetch(`${API}/${id}`, { method: "DELETE" });
    if (!res.ok) throw new Error("DELETE failed");

    accountList = accountList.filter(acc => acc.id != id);

    alert("Account Deleted!");

    saveToStorage();
    loadBranchDropdown();
    applyFilters();
    updateTotalBalance();
  } catch (error) {
    console.log("Error deleting account:", error.message);
    alert("Account not deleted!");
  }
}

//Task 7 View History
function viewHistory(id) {
  const acc = accountList.find(a => a.id == id);

  if (!acc.transactions || acc.transactions.length === 0) {
    alert("No transactions yet.");
    return;
  }

  let msg = `Transaction History for ${acc.name}:\n\n`;

  acc.transactions.forEach((t, index) => {
    msg += `${index + 1}. ${t.type} - ₹${t.amount} (${t.time})\n`;
  });

  alert(msg);
}

//Task 10 Sort
document.getElementById("sortBtn").addEventListener("click", function () {
  accountList.sort((a, b) => Number(b.balance) - Number(a.balance)); 
  saveToStorage();
  applyFilters();
});
fetchAccounts();
