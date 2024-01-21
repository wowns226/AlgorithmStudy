#include <iostream>
#include <vector>
#include <climits>

using namespace std;

int ans = INT_MAX;
bool selected[13];
int n, m;

void dfs(vector<pair<int, int>>& chick, vector<pair<int, int>>& houses, int n, int idx) {
	if (m == n) {
		int s = 0;
		for (int i = 0; i < houses.size(); ++i) {
			int mini = INT_MAX;
			for (int j = 0; j < 13; ++j) {
				if (selected[j]) {
					int dist = abs(chick[j].first - houses[i].first) + abs(chick[j].second - houses[i].second);
					if (mini > dist)
						mini = dist;
				}
			}
			s += mini;
		}
		if (ans > s)
			ans = s;
		return;
	}
	for (int i = idx; i < chick.size(); ++i) {
		if (selected[i] == true)
			continue;
		selected[i] = true;
		dfs(chick, houses, n + 1, i);
		selected[i] = false;
	}
}

int main() {
	cin >> n >> m;
	vector<pair<int, int>> houses;
	vector<pair<int, int>> chicken;
	for (int i = 0; i < n; ++i) {
		for (int j = 0; j < n; ++j) {
			int temp;
			cin >> temp;
			if (temp == 1)
				houses.push_back({ i, j });
			else if (temp == 2)
				chicken.push_back({ i, j });
		}
	}

	// Ä¡Å²ÁýÁß m°³ °ñ¶ó¾ßµÊ
	// °æ¿ìÀÇ ¼ö ´Ù ÇØºÁ¾ß ÇÒµ¡
	for (int i = 0; i <= chicken.size() - m; ++i) {
		selected[i] = true;
		dfs(chicken, houses, 1, i);
		selected[i] = false;
	}
	cout << ans;

	return 0;
}