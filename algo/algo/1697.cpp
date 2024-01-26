#include <iostream>
#include <vector>
#include <queue>
using namespace std;

int main() {
	int n, k;
	cin >> n >> k;
	vector<int> v;
	v.resize(100001, 100000);
	v[n] = 0;
	queue<int> q;
	q.push(n);
	bool flag = true;
	while (flag && q.size() > 0) {
		int now = q.front();
		q.pop();
		int nextDir[3] = { 1, -1, now};
		for (int i = 0; i < 3; ++i) {
			int next = now + nextDir[i];
			if (next >= 0 && next <= 100000 && v[next] > v[now] + 1) {
				v[next] = v[now] + 1;
				if (k == next) {
					flag = false;
					break;
				}
				q.push(next);
			}
		}
	}
	cout << v[k];

	return 0;
}