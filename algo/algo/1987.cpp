#include <iostream>
#include <string>
#include <vector>
#include <queue>

using namespace std;

int r, c;
int dx[4] = { 1, 0, -1, 0 };
int dy[4] = { 0, 1, 0, -1 };
vector<string> board;
vector<int> visited;
int ans = 0;

void dfs(int x, int y, int cnt);

int main() {
	
	cin >> r >> c;
	visited.resize(26, 0);
	board.resize(r, "");
	for (int i = 0; i < r; ++i) {
		string a;
		cin >> a;
		board[i] = a;
	}
	visited[board[0][0] - 'A'] = 1;
	dfs(0, 0, 1);
	cout << ans;
	return 0;
}

void dfs(int x, int y, int cnt) {
	ans = max(ans, cnt);
	for (int i = 0; i < 4; ++i) {
		pair<int, int> next = { x + dx[i], y + dy[i] };
		if (next.first >= 0 && next.first < r && next.second >= 0 && next.second < c
			&& visited[board[next.first][next.second] - 'A'] == 0) {
			visited[board[next.first][next.second] - 'A'] = 1;
			dfs(next.first, next.second, cnt + 1);
			visited[board[next.first][next.second] - 'A'] = 0;
		}
	}
}