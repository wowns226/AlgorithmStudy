#include <iostream>
#include <vector>

using namespace std;

int main() {
	int n, l;
	cin >> n >> l;
	vector<vector<int>> board;
	for (int i = 0; i < n; ++i) {
		vector<int> temp;
		for (int j = 0; j < n; ++j) {
			int k;
			cin >> k;
			temp.push_back(k);
		}
		board.push_back(temp);
	}
	int ans = 0;
	// 행 체크
	for (int i = 0; i < n; ++i) {
		vector<int> slope;
		slope.push_back(0);
		bool flag = true;
		int space = 0;
		int prev = board[i][0];
		// 왼 > 오
		for (int j = 1; j < n; ++j) {
			if(prev - board[i][j] > 1) { // 낮은 칸과 높은 칸의 높이 차이가 1이 아닌 경우
				flag = false;
				break;
			}
			if (prev > board[i][j] && space > 0) { // 낮은 지점의 칸의 높이가 모두 같지 않거나, L개가 연속되지 않은 경우
				flag = false;
				break;
			}

			if (prev > board[i][j]) {
				slope.push_back(1);
				prev = board[i][j];
				space = l - 1;
			}
			else if (prev == board[i][j] && space > 0) {
				slope.push_back(1);
				space -= 1;
			}
			else {
				slope.push_back(0);
				prev = board[i][j];
			}
		}
		if (space > 0) // 경사로를 놓다가 범위를 벗어나는 경우
			continue;
		// 오 > 왼
		prev = board[i][n - 1];
		for (int j = n - 2; j >= 0; --j) {
			if (prev - board[i][j] > 1) { // 낮은 칸과 높은 칸의 높이 차이가 1이 아닌 경우
				flag = false;
				break;
			}
			if (prev > board[i][j] && space > 0) { // 낮은 지점의 칸의 높이가 모두 같지 않거나, L개가 연속되지 않은 경우
				flag = false;
				break;
			}
			// 이제 경사 겹치는지도 확인해야됨
			if (prev > board[i][j]) {
				if (slope[j] == 1) {
					flag = false;
					break;
				}
				prev = board[i][j];
				space = l - 1;
			}
			else if (prev == board[i][j] && space > 0) {
				if (slope[j] == 1) {
					flag = false;
					break;
				}
				space -= 1;
			}
			else {
				prev = board[i][j];
			}
		}
		if (space > 0) // 경사로를 놓다가 범위를 벗어나는 경우
			continue;
		if (flag)
			ans += 1;

	}

	// 열 체크
	for (int i = 0; i < n; ++i) {
		vector<int> slope;
		slope.push_back(0);
		bool flag = true;
		int space = 0;
		int prev = board[0][i];
		// 왼 > 오
		for (int j = 1; j < n; ++j) {
			if (prev - board[j][i] > 1) { // 낮은 칸과 높은 칸의 높이 차이가 1이 아닌 경우
				flag = false;
				break;
			}
			if (prev > board[j][i] && space > 0) { // 낮은 지점의 칸의 높이가 모두 같지 않거나, L개가 연속되지 않은 경우
				flag = false;
				break;
			}

			if (prev > board[j][i]) {
				slope.push_back(1);
				prev = board[j][i];
				space = l - 1;
			}
			else if (prev == board[j][i] && space > 0) {
				slope.push_back(1);
				space -= 1;
			}
			else {
				slope.push_back(0);
				prev = board[j][i];
			}
		}
		if (space > 0) // 경사로를 놓다가 범위를 벗어나는 경우
			continue;
		// 오 > 왼
		prev = board[n - 1][i];
		for (int j = n - 2; j >= 0; --j) {
			if (prev - board[j][i] > 1) { // 낮은 칸과 높은 칸의 높이 차이가 1이 아닌 경우
				flag = false;
				break;
			}
			if (prev > board[j][i] && space > 0) { // 낮은 지점의 칸의 높이가 모두 같지 않거나, L개가 연속되지 않은 경우
				flag = false;
				break;
			}
			// 이제 경사 겹치는지도 확인해야됨
			if (prev > board[j][i]) {
				if (slope[j] == 1) {
					flag = false;
					break;
				}
				prev = board[j][i];
				space = l - 1;
			}
			else if (prev == board[j][i] && space > 0) {
				if (slope[j] == 1) {
					flag = false;
					break;
				}
				space -= 1;
			}
			else {
				prev = board[j][i];
			}
		}
		if (space > 0) // 경사로를 놓다가 범위를 벗어나는 경우
			continue;
		if (flag)
			ans += 1;
	}
	cout << ans;
}