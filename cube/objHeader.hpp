    
    class MyObj
    {
    private:
        int test;
    public:
        MyObj(int value){
            test = value;
        };
        ~MyObj(){
            
        };
        void SetTest(int value);
        int GetTest();
    };
    