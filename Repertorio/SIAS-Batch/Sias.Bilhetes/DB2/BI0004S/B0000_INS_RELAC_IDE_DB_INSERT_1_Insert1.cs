using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0004S
{
    public class B0000_INS_RELAC_IDE_DB_INSERT_1_Insert1 : QueryBasis<B0000_INS_RELAC_IDE_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.IDENTIFICA_RELAC
            VALUES (:BI0004L-S-COD-IDE ,
            :WS-COD-PES-004 ,
            :PRDSIVPF-COD-RELAC ,
            :BI0004L-E-COD-USU ,
            CURRENT TIMESTAMP )
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.IDENTIFICA_RELAC VALUES ({FieldThreatment(this.BI0004L_S_COD_IDE)} , {FieldThreatment(this.WS_COD_PES_004)} , {FieldThreatment(this.PRDSIVPF_COD_RELAC)} , {FieldThreatment(this.BI0004L_E_COD_USU)} , CURRENT TIMESTAMP )";

            return query;
        }
        public string BI0004L_S_COD_IDE { get; set; }
        public string WS_COD_PES_004 { get; set; }
        public string PRDSIVPF_COD_RELAC { get; set; }
        public string BI0004L_E_COD_USU { get; set; }

        public static void Execute(B0000_INS_RELAC_IDE_DB_INSERT_1_Insert1 b0000_INS_RELAC_IDE_DB_INSERT_1_Insert1)
        {
            var ths = b0000_INS_RELAC_IDE_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override B0000_INS_RELAC_IDE_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}