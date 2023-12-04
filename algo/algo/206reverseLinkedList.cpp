#include <stack>
#include <iostream>

using std::stack;
using std::cout;
using std::cin;

struct ListNode {
    int val;
    ListNode* next;
    ListNode() : val(0), next(nullptr) {}
    ListNode(int x) : val(x), next(nullptr) {}
    ListNode(int x, ListNode* next) : val(x), next(next) {}    
};

class Solution {
public:
    ListNode* reverseList(ListNode* head) {
        stack<ListNode*> s;
        if (head == nullptr)
            return nullptr;
        while (head != nullptr) {
            s.push(head);
            head = head->next;
        }
        ListNode* answer = s.top();
        s.pop();
        ListNode* iter = answer;
        while (s.size() > 0) {
            iter->next = s.top();
            s.pop();
            iter = iter->next;
        }
        iter->next = nullptr;
        return answer;

    }
};