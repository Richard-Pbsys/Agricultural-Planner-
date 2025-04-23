namespace VHS.Services.Common
{
    public static class GlobalConstants
    {
        public static Guid RACKTYPE_GROWING = new Guid("4a478cc6-a4dd-4210-9f09-e02cbf0fbe81");
        public static Guid RACKTYPE_GERMINATION = new Guid("7b901e37-803e-45d8-833d-4a6dcf77f172");
        public static Guid RACKTYPE_PROPAGATION = new Guid("b77de880-5105-49eb-8a1a-43f1bd7bf15e");
        public static Guid RACKTYPE_HARVESTING = new Guid("c3d1e2f4-5b6a-47c8-9d10-abcdef012345");
        public static Guid RACKTYPE_WASHING = new Guid("a9b8c7d6-e5f4-3210-fedc-ba9876543210");

        public static Guid PRODUCTCATEGORY_LETTUCE = new Guid("90e1ee66-1949-4ffd-88a4-3809c32739de");
        public static Guid PRODUCTCATEGORY_MICROGREENS = new Guid("3a0c8cc4-18a8-41e2-afc9-4b51fc288f1c");
        public static Guid PRODUCTCATEGORY_PETITEGREENS = new Guid("173fc70b-3475-4303-b9bd-c49870af13bf");

        public static Guid TRAYSTATUS_INUSE = new Guid("b146c4f2-05f5-4a36-9b5d-73b8f2b5d18f");
        public static Guid TRAYSTATUS_BROKEN = new Guid("e2d2c3e9-9b47-499e-b8e6-3b74636bf9d5");
        public static Guid TRAYSTATUS_REMOVED = new Guid("9f3c324d-d59c-4707-a5e2-6a6a34fc7c5d");

        public static Guid TRAYPHASE_EMPTY = new Guid("95e503d0-32b7-4601-954b-e3212d2adaa0");
        public static Guid TRAYPHASE_SEEDED = new Guid("26db4fd6-b800-4978-9268-2c244913fb92");
        public static Guid TRAYPHASE_GERMINATING = new Guid("30ed163a-400c-4749-96ae-b805c1851b19");
        public static Guid TRAYPHASE_PROPAGATING = new Guid("05a1b6f1-7994-49be-bc76-dacd950e315a");
        public static Guid TRAYPHASE_REPLANTED = new Guid("5b6b3baf-08fe-428e-82f6-1dc8728a5b1a");
        public static Guid TRAYPHASE_GROWING = new Guid("2723daf2-aa55-4520-8379-485dbce94626");
        public static Guid TRAYPHASE_FULLYGERMINATED = new Guid("6f8ff0b6-26ed-4cfe-99f8-ed5db8821091");
        public static Guid TRAYPHASE_FULLYPROPAGATED = new Guid("dd073b27-9840-452d-a99d-f34a0eacc210");
        public static Guid TRAYPHASE_FULLYGROWN = new Guid("e60fa5c0-bf7d-4f07-89cd-901be9f73549");
        public static Guid TRAYPHASE_TOHARVESTING = new Guid("c41b5f6b-e6eb-4949-90b3-d57074b6f2d2");
        public static Guid TRAYPHASE_HARVESTED = new Guid("8627bb2a-b490-4175-8f3c-7838d9a700b6");
        public static Guid TRAYPHASE_TOWASHING = new Guid("31c03169-94cb-4545-b1aa-2ce1594fcc67");
        public static Guid TRAYPHASE_WASHED = new Guid("4a98837e-cb07-4644-85d9-039e1b4dd118");
        public static Guid TRAYPHASE_INFEEDER = new Guid("a50d5a10-7d80-4ade-8e74-025dbb1faef7");

        public static Guid BATCHSTATUS_PENDING = new Guid("afca571c-fa99-4040-becb-8412889b097f");
        public static Guid BATCHSTATUS_INPROGRESS = new Guid("e5fdb3fb-4d05-4644-816a-8d08a3be92ef");
        public static Guid BATCHSTATUS_HARVESTED = new Guid("47015bfd-9eb9-4bfa-93bf-6aa009ca8c79");
        public static Guid BATCHSTATUS_COMPLETED = new Guid("3d6036ea-63c7-441d-aba8-6a8b677bc0a4");
        public static Guid BATCHSTATUS_CANCELLED = new Guid("01909ed6-e9db-435d-a3c3-cccc0c614a0d");
    }
}
