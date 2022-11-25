namespace AtolDriver
{
    class Program
    {
        static void Main(string[] args)
        {
            int port = 3;
            int baudRate = 115200;

            string operatorName = "Xobnail";
            string operatorInn = null;

            var printer = new Interface(port, baudRate);
            printer.OpenConnection();
            printer.GetShiftStatus();
            var strin = printer.GetDocument(69);
            // printer.GetPicture();
            printer.SetOperator(operatorName, operatorInn);
            printer.OpenShift();
            printer.OpenReceipt(true ,TypeReceipt.Sell, TaxationTypeEnum.Osn);
            printer.AddPosition("Норка", 15, 1,MeasurementUnitEnum.Piece, PaymentObjectEnum.Commodity, TaxTypeEnum.Vat20);
            // printer.PrintStatus();
            printer.AddPosition("Ручка", 20, 1, MeasurementUnitEnum.Piece, PaymentObjectEnum.Commodity, TaxTypeEnum.Vat20);
            // printer.PrintStatus();
            printer.Pay(PaymentTypeEnum.cash, 35);
            printer.CloseReceipt();
            // printer.PrintStatus();
            printer.CloseShift();
        }
    }
}