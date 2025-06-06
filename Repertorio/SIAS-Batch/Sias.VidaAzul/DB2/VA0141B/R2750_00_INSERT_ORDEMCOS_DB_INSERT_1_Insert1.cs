using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0141B
{
    public class R2750_00_INSERT_ORDEMCOS_DB_INSERT_1_Insert1 : QueryBasis<R2750_00_INSERT_ORDEMCOS_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.ORDEM_COSSEGCED
            (NUM_APOLICE
            ,NUM_ENDOSSO
            ,COD_COSSEGURADORA
            ,ORDEM_CEDIDO
            ,COD_EMPRESA
            ,TIMESTAMP)
            VALUES
            (:PARCEHIS-NUM-APOLICE
            ,:PARCEHIS-NUM-ENDOSSO
            ,:APOLCOSS-COD-COSSEGURADORA
            ,:NUMERCOS-SEQ-ORD-CEDIDO
            ,:PARCEHIS-COD-EMPRESA:VIND-COD-EMPRESA
            , CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.ORDEM_COSSEGCED (NUM_APOLICE ,NUM_ENDOSSO ,COD_COSSEGURADORA ,ORDEM_CEDIDO ,COD_EMPRESA ,TIMESTAMP) VALUES ({FieldThreatment(this.PARCEHIS_NUM_APOLICE)} ,{FieldThreatment(this.PARCEHIS_NUM_ENDOSSO)} ,{FieldThreatment(this.APOLCOSS_COD_COSSEGURADORA)} ,{FieldThreatment(this.NUMERCOS_SEQ_ORD_CEDIDO)} , {FieldThreatment((this.VIND_COD_EMPRESA?.ToInt() == -1 ? null : this.PARCEHIS_COD_EMPRESA))} , CURRENT TIMESTAMP)";

            return query;
        }
        public string PARCEHIS_NUM_APOLICE { get; set; }
        public string PARCEHIS_NUM_ENDOSSO { get; set; }
        public string APOLCOSS_COD_COSSEGURADORA { get; set; }
        public string NUMERCOS_SEQ_ORD_CEDIDO { get; set; }
        public string PARCEHIS_COD_EMPRESA { get; set; }
        public string VIND_COD_EMPRESA { get; set; }

        public static void Execute(R2750_00_INSERT_ORDEMCOS_DB_INSERT_1_Insert1 r2750_00_INSERT_ORDEMCOS_DB_INSERT_1_Insert1)
        {
            var ths = r2750_00_INSERT_ORDEMCOS_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2750_00_INSERT_ORDEMCOS_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}