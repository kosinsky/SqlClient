// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using Xunit;

namespace Microsoft.Data.SqlClient.ManualTesting.Tests
{
    public class SqlBulkCopyTest
    {
        private string _connStr = null;
        private static bool IsAzureServer() => !DataTestUtility.IsNotAzureServer();
        private static bool IsNotAzureSynapse => DataTestUtility.IsNotAzureSynapse();
        private static bool AreConnectionStringsSetup() => DataTestUtility.AreConnStringsSetup();

        public SqlBulkCopyTest()
        {
            _connStr = DataTestUtility.TCPConnectionString;
        }

        public string AddGuid(string stringin)
        {
            stringin += "_" + Guid.NewGuid().ToString().Replace('-', '_');
            return stringin;
        }

        // Synapse: Promote Transaction not supported by Azure Synapse
        [ConditionalFact(nameof(AreConnectionStringsSetup), nameof(IsNotAzureSynapse), nameof(IsAzureServer))]
        public void AzureDistributedTransactionTest()
        {
            AzureDistributedTransaction.Test();
        }

        // Fabric DW: INSERT BULK not supported
        [ConditionalFact(typeof(DataTestUtility), nameof(DataTestUtility.AreConnStringsSetup), nameof(DataTestUtility.IsNotAzureServer), nameof(DataTestUtility.IsNotFabricDW))]
        public void CopyAllFromReaderTest()
        {
            CopyAllFromReader.Test(_connStr, _connStr, AddGuid("SqlBulkCopyTest_CopyAllFromReader"));
        }

        // Fabric DW: INSERT BULK not supported
        [ConditionalFact(typeof(DataTestUtility), nameof(DataTestUtility.AreConnStringsSetup), nameof(DataTestUtility.IsNotAzureServer), nameof(DataTestUtility.IsNotFabricDW))]
        public void CopyAllFromReader1Test()
        {
            CopyAllFromReader1.Test(_connStr, _connStr, AddGuid("SqlBulkCopyTest_CopyAllFromReader1"));
        }

        // Fabric DW: INSERT BULK not supported
        [ConditionalFact(typeof(DataTestUtility), nameof(DataTestUtility.AreConnStringsSetup), nameof(DataTestUtility.IsNotAzureServer), nameof(DataTestUtility.IsNotFabricDW))]
        public void CopyMultipleReadersTest()
        {
            CopyMultipleReaders.Test(_connStr, _connStr, AddGuid("SqlBulkCopyTest_CopyMultipleReaders"));
        }

        // Fabric DW: INSERT BULK not supported
        [ConditionalFact(typeof(DataTestUtility), nameof(DataTestUtility.AreConnStringsSetup), nameof(DataTestUtility.IsNotAzureServer), nameof(DataTestUtility.IsNotFabricDW))]
        public void CopySomeFromReaderTest()
        {
            CopySomeFromReader.Test(_connStr, _connStr, AddGuid("SqlBulkCopyTest_CopySomeFromReader"));
        }

        // Fabric DW: INSERT BULK not supported
        [ConditionalFact(typeof(DataTestUtility), nameof(DataTestUtility.AreConnStringsSetup), nameof(DataTestUtility.IsNotAzureServer), nameof(DataTestUtility.IsNotFabricDW))]
        public void CopySomeFromDataTableTest()
        {
            CopySomeFromDataTable.Test(_connStr, _connStr, AddGuid("SqlBulkCopyTest_CopySomeFromDataTable"));
        }

        // Fabric DW: INSERT BULK not supported
        [ConditionalFact(typeof(DataTestUtility), nameof(DataTestUtility.AreConnStringsSetup), nameof(DataTestUtility.IsNotAzureServer), nameof(DataTestUtility.IsNotFabricDW))]
        public void CopySomeFromRowArrayTest()
        {
            CopySomeFromRowArray.Test(_connStr, _connStr, AddGuid("SqlBulkCopyTest_CopySomeFromRowArray"));
        }

        // Fabric DW: INSERT BULK not supported
        [ConditionalFact(typeof(DataTestUtility), nameof(DataTestUtility.AreConnStringsSetup), nameof(DataTestUtility.IsNotAzureServer), nameof(DataTestUtility.IsNotFabricDW))]
        public void CopyWithEventTest()
        {
            CopyWithEvent.Test(_connStr, _connStr, AddGuid("SqlBulkCopyTest_CopyWithEvent"));
        }

        // Fabric DW: INSERT BULK not supported
        [ConditionalFact(typeof(DataTestUtility), nameof(DataTestUtility.AreConnStringsSetup), nameof(DataTestUtility.IsNotAzureServer), nameof(DataTestUtility.IsNotFabricDW))]
        public void CopyWithEvent1Test()
        {
            CopyWithEvent1.Test(_connStr, _connStr, AddGuid("SqlBulkCopyTest_CopyWithEvent1"));
        }

        // Fabric DW: INSERT BULK not supported
        [ConditionalFact(typeof(DataTestUtility), nameof(DataTestUtility.AreConnStringsSetup), nameof(DataTestUtility.IsNotAzureServer), nameof(DataTestUtility.IsNotFabricDW))]
        public void InvalidAccessFromEventTest()
        {
            InvalidAccessFromEvent.Test(_connStr, _connStr, AddGuid("SqlBulkCopyTest_InvalidAccessFromEvent"));
        }

        // Fabric DW: INSERT BULK not supported
        [ConditionalFact(typeof(DataTestUtility), nameof(DataTestUtility.AreConnStringsSetup), nameof(DataTestUtility.IsNotAzureServer), nameof(DataTestUtility.IsNotFabricDW))]
        public void Bug84548Test()
        {
            Bug84548.Test(_connStr, _connStr, AddGuid("SqlBulkCopyTest_Bug84548"));
        }

        // Fabric DW: INSERT BULK not supported
        [ConditionalFact(typeof(DataTestUtility), nameof(DataTestUtility.AreConnStringsSetup), nameof(DataTestUtility.IsNotAzureServer), nameof(DataTestUtility.IsNotFabricDW))]
        public void MissingTargetTableTest()
        {
            MissingTargetTable.Test(_connStr, _connStr, AddGuid("@SqlBulkCopyTest_MissingTargetTable"));
        }

        // Fabric DW: INSERT BULK not supported
        [ConditionalFact(typeof(DataTestUtility), nameof(DataTestUtility.AreConnStringsSetup), nameof(DataTestUtility.IsNotAzureServer), nameof(DataTestUtility.IsNotFabricDW))]
        public void MissingTargetColumnTest()
        {
            MissingTargetColumn.Test(_connStr, _connStr, AddGuid("SqlBulkCopyTest_MissingTargetColumn"));
        }

        // Fabric DW: INSERT BULK not supported
        [ConditionalFact(typeof(DataTestUtility), nameof(DataTestUtility.AreConnStringsSetup), nameof(DataTestUtility.IsNotAzureServer), nameof(DataTestUtility.IsNotFabricDW))]
        public void MissingTargetColumnsTest()
        {
            MissingTargetColumns.Test(_connStr, _connStr, AddGuid("SqlBulkCopyTest_MissingTargetColumns"));
        }

        // Fabric DW: INSERT BULK not supported
        [ConditionalFact(typeof(DataTestUtility), nameof(DataTestUtility.AreConnStringsSetup), nameof(DataTestUtility.IsNotAzureServer), nameof(DataTestUtility.IsNotFabricDW))]
        public void Bug85007Test()
        {
            Bug85007.Test(_connStr, _connStr, AddGuid("SqlBulkCopyTest_Bug85007"));
        }

        // Fabric DW: INSERT BULK not supported
        [ConditionalFact(typeof(DataTestUtility), nameof(DataTestUtility.AreConnStringsSetup), nameof(DataTestUtility.IsNotAzureServer), nameof(DataTestUtility.IsNotFabricDW))]
        public void CheckConstraintsTest()
        {
            CheckConstraints.Test(_connStr, AddGuid("SqlBulkCopyTest_Extensionsrc"), AddGuid("SqlBulkCopyTest_Extensiondst"));
        }

        // Fabric DW: INSERT BULK not supported
        [ConditionalFact(typeof(DataTestUtility), nameof(DataTestUtility.AreConnStringsSetup), nameof(DataTestUtility.IsNotAzureServer), nameof(DataTestUtility.IsNotFabricDW))]
        public void TableLockTest()
        {
            TableLock.Test(_connStr, _connStr, AddGuid("SqlBulkCopyTest_TableLock0"), AddGuid("SqlBulkCopyTest_TableLock1"));
        }

        // Fabric DW: INSERT BULK not supported
        [ConditionalFact(typeof(DataTestUtility), nameof(DataTestUtility.AreConnStringsSetup), nameof(DataTestUtility.IsNotAzureServer), nameof(DataTestUtility.IsNotFabricDW))]
        public void KeepNullsTest()
        {
            KeepNulls.Test(_connStr, _connStr, AddGuid("SqlBulkCopyTest_KeepNulls0"), AddGuid("SqlBulkCopyTest_KeepNulls1"));
        }

        // Fabric DW: INSERT BULK not supported
        [ConditionalFact(typeof(DataTestUtility), nameof(DataTestUtility.AreConnStringsSetup), nameof(DataTestUtility.IsNotAzureServer), nameof(DataTestUtility.IsNotFabricDW))]
        public void TransactionTest()
        {
            Transaction.Test(_connStr, _connStr, AddGuid("SqlBulkCopyTest_Transaction0"));
        }

        // Fabric DW: INSERT BULK not supported
        [ConditionalFact(typeof(DataTestUtility), nameof(DataTestUtility.AreConnStringsSetup), nameof(DataTestUtility.IsNotAzureServer), nameof(DataTestUtility.IsNotFabricDW))]
        public void Transaction1Test()
        {
            Transaction1.Test(_connStr, _connStr, AddGuid("SqlBulkCopyTest_Transaction1"));
        }

        // Fabric DW: INSERT BULK not supported
        [ConditionalFact(typeof(DataTestUtility), nameof(DataTestUtility.AreConnStringsSetup), nameof(DataTestUtility.IsNotAzureServer), nameof(DataTestUtility.IsNotFabricDW))]
        public void Transaction2Test()
        {
            Transaction2.Test(_connStr, _connStr, AddGuid("SqlBulkCopyTest_Transaction2"));
        }

        // Fabric DW: INSERT BULK not supported
        [ConditionalFact(typeof(DataTestUtility), nameof(DataTestUtility.AreConnStringsSetup), nameof(DataTestUtility.IsNotAzureServer), nameof(DataTestUtility.IsNotFabricDW))]
        public void Transaction3Test()
        {
            Transaction3.Test(_connStr, _connStr, AddGuid("SqlBulkCopyTest_Transaction3"));
        }

        // Fabric DW: INSERT BULK not supported
        [ConditionalFact(typeof(DataTestUtility), nameof(DataTestUtility.AreConnStringsSetup), nameof(DataTestUtility.IsNotAzureServer), nameof(DataTestUtility.IsNotFabricDW))]
        public void Transaction4Test()
        {
            Transaction4.Test(_connStr, _connStr, AddGuid("SqlBulkCopyTest_Transaction4"));
        }

        // Fabric DW: INSERT BULK not supported
        [ConditionalFact(typeof(DataTestUtility), nameof(DataTestUtility.AreConnStringsSetup), nameof(DataTestUtility.IsNotAzureServer), nameof(DataTestUtility.IsNotFabricDW))]
        public void CopyVariantsTest()
        {
            CopyVariants.Test(_connStr, AddGuid("SqlBulkCopyTest_Variants"));
        }

        // Fabric DW: INSERT BULK not supported
        [ConditionalFact(typeof(DataTestUtility), nameof(DataTestUtility.AreConnStringsSetup), nameof(DataTestUtility.IsNotAzureServer), nameof(DataTestUtility.IsNotFabricDW))]
        public void Bug98182Test()
        {
            Bug98182.Test(_connStr, AddGuid("@SqlBulkCopyTest_Bug98182 "));
        }

        // Fabric DW: INSERT BULK not supported
        [ConditionalFact(typeof(DataTestUtility), nameof(DataTestUtility.AreConnStringsSetup), nameof(DataTestUtility.IsNotAzureServer), nameof(DataTestUtility.IsNotFabricDW))]
        public void FireTriggerTest()
        {
            FireTrigger.Test(_connStr, _connStr, AddGuid("SqlBulkCopyTest_FireTrigger"));
        }

        // Fabric DW: INSERT BULK not supported
        [ConditionalFact(typeof(DataTestUtility), nameof(DataTestUtility.AreConnStringsSetup), nameof(DataTestUtility.IsNotAzureServer), nameof(DataTestUtility.IsNotFabricDW))]
        public void ErrorOnRowsMarkedAsDeletedTest()
        {
            ErrorOnRowsMarkedAsDeleted.Test(_connStr, AddGuid("SqlBulkCopyTest_ErrorOnRowsMarkedAsDeleted"));
        }

        // Fabric DW: INSERT BULK not supported
        [ConditionalFact(typeof(DataTestUtility), nameof(DataTestUtility.AreConnStringsSetup), nameof(DataTestUtility.IsNotAzureServer), nameof(DataTestUtility.IsNotFabricDW))]
        public void SpecialCharacterNamesTest()
        {
            SpecialCharacterNames.Test(_connStr, _connStr, AddGuid("@SqlBulkCopyTest_SpecialCharacterNames"));
        }

        // Fabric DW: INSERT BULK not supported
        [ConditionalFact(typeof(DataTestUtility), nameof(DataTestUtility.AreConnStringsSetup), nameof(DataTestUtility.IsNotAzureServer), nameof(DataTestUtility.IsNotFabricDW))]
        public void Bug903514Test()
        {
            Bug903514.Test(_connStr, AddGuid("SqlBulkCopyTest_Bug903514"));
        }

        // Fabric DW: INSERT BULK not supported
        [ConditionalFact(typeof(DataTestUtility), nameof(DataTestUtility.AreConnStringsSetup), nameof(DataTestUtility.IsNotAzureServer), nameof(DataTestUtility.IsNotFabricDW))]
        public void ColumnCollationTest()
        {
            ColumnCollation.Test(_connStr, AddGuid("SqlBulkCopyTest_ColumnCollation"));
        }

        // Fabric DW: INSERT BULK not supported
        [ConditionalFact(typeof(DataTestUtility), nameof(DataTestUtility.AreConnStringsSetup), nameof(DataTestUtility.IsNotAzureServer), nameof(DataTestUtility.IsNotFabricDW))]
        public void CopyAllFromReaderAsyncTest()
        {
            CopyAllFromReaderAsync.Test(_connStr, _connStr, AddGuid("SqlBulkCopyTest_AsyncTest1")); //Async + Reader
        }

        // Fabric DW: INSERT BULK not supported
        [ConditionalFact(typeof(DataTestUtility), nameof(DataTestUtility.AreConnStringsSetup), nameof(DataTestUtility.IsNotAzureServer), nameof(DataTestUtility.IsNotFabricDW))]
        public void CopySomeFromRowArrayAsyncTest()
        {
            CopySomeFromRowArrayAsync.Test(_connStr, _connStr, AddGuid("SqlBulkCopyTest_AsyncTest2")); //Async + Some Rows
        }

        // Fabric DW: INSERT BULK not supported
        [ConditionalFact(typeof(DataTestUtility), nameof(DataTestUtility.AreConnStringsSetup), nameof(DataTestUtility.IsNotAzureServer), nameof(DataTestUtility.IsNotFabricDW))]
        public void CopySomeFromDataTableAsyncTest()
        {
            CopySomeFromDataTableAsync.Test(_connStr, _connStr, AddGuid("SqlBulkCopyTest_AsyncTest3")); //Async + Some Table
        }

        // Fabric DW: INSERT BULK not supported
        [ConditionalFact(typeof(DataTestUtility), nameof(DataTestUtility.AreConnStringsSetup), nameof(DataTestUtility.IsNotAzureServer), nameof(DataTestUtility.IsNotFabricDW))]
        public void CopyWithEventAsyncTest()
        {
            CopyWithEventAsync.Test(_connStr, _connStr, AddGuid("SqlBulkCopyTest_AsyncTest4")); //Async + Rows + Notification
        }

        // Fabric DW: INSERT BULK not supported
        [ConditionalFact(typeof(DataTestUtility), nameof(DataTestUtility.AreConnStringsSetup), nameof(DataTestUtility.IsNotFabricDW))]
        public void CopyAllFromReaderCancelAsyncTest()
        {
            CopyAllFromReaderCancelAsync.Test(_connStr, _connStr, AddGuid("SqlBulkCopyTest_AsyncTest5")); //Async + Reader + cancellation token
        }

        // Fabric DW: INSERT BULK not supported
        [ConditionalFact(typeof(DataTestUtility), nameof(DataTestUtility.AreConnStringsSetup), nameof(DataTestUtility.IsNotFabricDW))]
        public void CopyAllFromReaderConnectionClosedAsyncTest()
        {
            CopyAllFromReaderConnectionClosedAsync.Test(_connStr, _connStr, AddGuid("SqlBulkCopyTest_AsyncTest6")); //Async + Reader + Connection closed
        }

        // Fabric DW: INSERT BULK not supported
        [ConditionalFact(typeof(DataTestUtility), nameof(DataTestUtility.AreConnStringsSetup), nameof(DataTestUtility.IsNotFabricDW))]
        public void CopyAllFromReaderConnectionClosedOnEventAsyncTest()
        {
            CopyAllFromReaderConnectionClosedOnEventAsync.Test(_connStr, _connStr, AddGuid("SqlBulkCopyTest_AsyncTest7")); //Async + Reader + Connection closed during the event
        }

        // Fabric DW: INSERT BULK not supported
        [ConditionalFact(typeof(DataTestUtility), nameof(DataTestUtility.AreConnStringsSetup), nameof(DataTestUtility.IsNotFabricDW))]
        public void TransactionTestAsyncTest()
        {
            TransactionTestAsync.Test(_connStr, _connStr, AddGuid("SqlBulkCopyTest_TransactionTestAsync")); //Async + Transaction rollback
        }

        // Fabric DW: INSERT BULK not supported
        [ConditionalFact(typeof(DataTestUtility), nameof(DataTestUtility.AreConnStringsSetup), nameof(DataTestUtility.IsNotAzureServer), nameof(DataTestUtility.IsNotFabricDW))]
        public void CopyWidenNullInexactNumericsTest()
        {
            CopyWidenNullInexactNumerics.Test(_connStr, _connStr);
        }

        // Fabric DW: INSERT BULK not supported
        [ConditionalFact(typeof(DataTestUtility), nameof(DataTestUtility.AreConnStringsSetup), nameof(DataTestUtility.IsNotFabricDW))]
        public void DestinationTableNameWithSpecialCharTest()
        {
            DestinationTableNameWithSpecialChar.Test(_connStr, AddGuid("SqlBulkCopyTest_DestinationTableNameWithSpecialChar"));
        }

        // TODO Synapse: Remove dependency on Northwind database
        // Fabric DW: INSERT BULK not supported
        [ConditionalFact(typeof(DataTestUtility), nameof(DataTestUtility.AreConnStringsSetup), nameof(DataTestUtility.IsNotAzureSynapse), nameof(DataTestUtility.IsNotFabricDW))]
        public void OrderHintTest()
        {
            OrderHint.Test(_connStr, AddGuid("SqlBulkCopyTest_OrderHint"), AddGuid("SqlBulkCopyTest_OrderHint2"));
        }

        // Synapse: Cannot create more than one clustered index on table '<table_name>'.
        // Drop the existing clustered index 'ClusteredIndex_fe3d8c967ac142468ec4f81ff1faaa50' before creating another.
        // Fabric DW: INSERT BULK not supported
        [ConditionalFact(typeof(DataTestUtility), nameof(DataTestUtility.AreConnStringsSetup), nameof(DataTestUtility.IsNotAzureSynapse), nameof(DataTestUtility.IsNotFabricDW))]
        public void OrderHintAsyncTest()
        {
            OrderHintAsync.Test(_connStr, AddGuid("SqlBulkCopyTest_OrderHintAsync"), AddGuid("SqlBulkCopyTest_OrderHintAsync2"));
        }

        // Synapse: Remove dependency on Northwind database.
        // Fabric DW: INSERT BULK not supported
        [ConditionalFact(typeof(DataTestUtility), nameof(DataTestUtility.AreConnStringsSetup), nameof(DataTestUtility.IsNotAzureSynapse), nameof(DataTestUtility.IsNotFabricDW))]
        public void OrderHintMissingTargetColumnTest()
        {
            OrderHintMissingTargetColumn.Test(_connStr, AddGuid("SqlBulkCopyTest_OrderHintMissingTargetColumn"));
        }

        // Synapse: Remove dependency on Northwind database.
        // Fabric DW: INSERT BULK not supported
        [ConditionalFact(typeof(DataTestUtility), nameof(DataTestUtility.AreConnStringsSetup), nameof(DataTestUtility.IsNotAzureSynapse), nameof(DataTestUtility.IsNotFabricDW))]
        public void OrderHintDuplicateColumnTest()
        {
            OrderHintDuplicateColumn.Test(_connStr, AddGuid("SqlBulkCopyTest_OrderHintDuplicateColumn"));
        }

        // Synapse: 111212;Operation cannot be performed within a transaction.
        // Fabric DW: INSERT BULK not supported
        [ConditionalFact(typeof(DataTestUtility), nameof(DataTestUtility.AreConnStringsSetup), nameof(DataTestUtility.IsNotAzureSynapse), nameof(DataTestUtility.IsNotFabricDW))]
        public void OrderHintTransactionTest()
        {
            OrderHintTransaction.Test(_connStr, AddGuid("SqlBulkCopyTest_OrderHintTransaction"));
        }

        // Fabric DW: INSERT BULK not supported
        [ConditionalFact(typeof(DataTestUtility), nameof(DataTestUtility.AreConnStringsSetup), nameof(DataTestUtility.IsNotFabricDW))]
        [ActiveIssue("12219")]
        public void OrderHintIdentityColumnTest()
        {
            OrderHintIdentityColumn.Test(_connStr, AddGuid("SqlBulkCopyTest_OrderHintIdentityColumn"));
        }
    }
}
