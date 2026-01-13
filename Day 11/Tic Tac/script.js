// Game state
let board = ['', '', '', '', '', '', '', '', ''];
let currentPlayer = 'X';
let gameActive = true;

// Winning combinations
const winCombinations = [
    [0, 1, 2],
    [3, 4, 5],
    [6, 7, 8],
    [0, 3, 6],
    [1, 4, 7],
    [2, 5, 8],
    [0, 4, 8],
    [2, 4, 6]
];

// DOM elements
const cells = document.querySelectorAll('.cell');
const turnDisplay = document.getElementById('turn');
const statusDisplay = document.getElementById('status');
const resetBtn = document.getElementById('reset-btn');

// Event listeners
cells.forEach(cell => {
    cell.addEventListener('click', handleCellClick);
});
resetBtn.addEventListener('click', resetGame);

// Handle cell click
function handleCellClick(e) {
    const cell = e.target;
    const index = parseInt(cell.getAttribute('data-index'));

    // If cell is already filled or game is over, do nothing
    if (board[index] !== '' || !gameActive) return;

    // Update board and display
    board[index] = currentPlayer;
    cell.textContent = currentPlayer;
    cell.disabled = true;

    // Check for winner or draw
    checkResult();
}

// Check game result
function checkResult() {
    let hasWon = false;

    // Check for winning combination
    for (let combo of winCombinations) {
        const [a, b, c] = combo;
        if (board[a] === '' || board[b] === '' || board[c] === '') continue;
        if (board[a] === board[b] && board[b] === board[c]) {
            hasWon = true;
            break;
        }
    }

    if (hasWon) {
        statusDisplay.textContent = `🎉 Player ${currentPlayer} Wins!`;
        gameActive = false;
        return;
    }

    // Check for draw
    if (!board.includes('')) {
        statusDisplay.textContent = "It's a Draw!";
        gameActive = false;
        return;
    }

    // Switch player
    currentPlayer = currentPlayer === 'X' ? 'O' : 'X';
    turnDisplay.textContent = `Player ${currentPlayer}'s Turn`;
}

// Reset game
function resetGame() {
    board = ['', '', '', '', '', '', '', '', ''];
    currentPlayer = 'X';
    gameActive = true;
    statusDisplay.textContent = '';
    turnDisplay.textContent = `Player ${currentPlayer}'s Turn`;

    cells.forEach(cell => {
        cell.textContent = '';
        cell.disabled = false;
    });
}
