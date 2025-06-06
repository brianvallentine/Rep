using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0003B
{
    public class R1400_00_INSERT_ORDEMCOS_DB_INSERT_1_Insert1 : QueryBasis<R1400_00_INSERT_ORDEMCOS_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.ORDEM_COSSEGCED
            VALUES (:ORDEMCOS-NUM-APOLICE ,
            :ORDEMCOS-NUM-ENDOSSO ,
            :ORDEMCOS-COD-COSSEGURADORA ,
            :ORDEMCOS-ORDEM-CEDIDO ,
            :ORDEMCOS-COD-EMPRESA:VIND-COD-EMPR ,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.ORDEM_COSSEGCED VALUES ({FieldThreatment(this.ORDEMCOS_NUM_APOLICE)} , {FieldThreatment(this.ORDEMCOS_NUM_ENDOSSO)} , {FieldThreatment(this.ORDEMCOS_COD_COSSEGURADORA)} , {FieldThreatment(this.ORDEMCOS_ORDEM_CEDIDO)} ,  {FieldThreatment((this.VIND_COD_EMPR?.ToInt() == -1 ? null : this.ORDEMCOS_COD_EMPRESA))} , CURRENT TIMESTAMP)";

            return query;
        }
        public string ORDEMCOS_NUM_APOLICE { get; set; }
        public string ORDEMCOS_NUM_ENDOSSO { get; set; }
        public string ORDEMCOS_COD_COSSEGURADORA { get; set; }
        public string ORDEMCOS_ORDEM_CEDIDO { get; set; }
        public string ORDEMCOS_COD_EMPRESA { get; set; }
        public string VIND_COD_EMPR { get; set; }

        public static void Execute(R1400_00_INSERT_ORDEMCOS_DB_INSERT_1_Insert1 r1400_00_INSERT_ORDEMCOS_DB_INSERT_1_Insert1)
        {
            var ths = r1400_00_INSERT_ORDEMCOS_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1400_00_INSERT_ORDEMCOS_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}