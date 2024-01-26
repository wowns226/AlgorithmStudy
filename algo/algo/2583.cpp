#include <iostream>
#include <vector>
#include <algorithm>
#include <queue>

using namespace std;

vector<vector<int>> board;
int dx[4] = {-1, 0, 1, 0};
int dy[4] = {0, 1, 0, -1};
int m, n, k;

int bfs(int x, int y);

int main() {
	cin >> m >> n >> k;
	vector<int> ans;
	vector<int> temp;
	temp.resize(n, 0);
	board.resize(m, temp);
	for (int i = 0; i < k; ++i) {
		int lx, ly, rx, ry;
		cin >> lx >> ly >> rx >> ry;
		for (int col = ly; col < ry; ++col){
			for (int row = lx; row < rx; ++row)
				board[col][row] = 1;
		}
	}
	for (int i = 0; i < m; ++i) {
		for (int j = 0; j < n; ++j) {
			if (board[i][j] == 0)
				ans.push_back(bfs(i, j));
		}
	}
	sort(ans.begin(), ans.end());
	cout << ans.size() << endl;
	for (int i = 0; i < ans.size(); ++i) {
		cout << ans[i] << " ";
	}
}

int bfs(int x, int y) {
	queue<pair<int, int>> q;
	int cnt = 1;
	board[x][y] = 1;
	q.push({ x, y });
	while (q.size() > 0) {
		pair<int, int> a = q.front();
		q.pop();
		for (int i = 0; i < 4; ++i) {
			int nx = a.first + dx[i];
			int ny = a.second + dy[i];
			if (nx >= 0 && nx < m && ny >= 0 && ny < n && board[nx][ny] == 0) {
				board[nx][ny] = 1;
				cnt += 1;
				q.push({ nx, ny });
			}
		}
	}
	return cnt;
}