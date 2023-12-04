struct ListNode {
    int val;
    ListNode *next;
    ListNode() : val(0), next(nullptr) {}
    ListNode(int x) : val(x), next(nullptr) {}
    ListNode(int x, ListNode *next) : val(x), next(next) {}
};

class Solution {
public:
    ListNode* addTwoNumbers(ListNode* l1, ListNode* l2) {
        int add1 = 0;
        ListNode* answer = new ListNode;
        ListNode* iter = answer;
        ListNode* prev = iter;
        while (l1 != nullptr || l2 != nullptr) {
            if (l1 != nullptr && l2 != nullptr) {
                iter->val = (l1->val + l2->val + add1) % 10;
                add1 = (l1->val + l2->val + add1) / 10;
                l1 = l1->next;
                l2 = l2->next;
            }
            else if (l1 != nullptr) {
                iter->val = (l1->val + add1) % 10;
                add1 = (l1->val + add1) / 10;
                l1 = l1->next;
            }
            else if (l2 != nullptr) {
                iter->val = (l2->val + add1) % 10;
                add1 = (l2->val + add1) / 10;
                l2 = l2->next;
            }
            iter->next = new ListNode;
            prev = iter;
            iter = iter->next;
        }
        if (add1 > 0) {
            iter->val = 1;
        }
        else {
            prev->next = nullptr;
        }
        return answer;
    }
};