using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI1630B
{
    public class M_19300_00_INS_GE_DOC_DB_INSERT_1_Insert1 : QueryBasis<M_19300_00_INS_GE_DOC_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.GE_DOC_CLIENTE
            (COD_CLIENTE ,
            COD_IDENTIFICACAO ,
            NOM_ORGAO_EXP ,
            DTH_EXPEDICAO ,
            COD_UF)
            VALUES (:WS-COD-CLI-ATU ,
            :BI0005L-S-NUM-IDENT ,
            :BI0005L-S-ORGAO-EXPED ,
            :BI0005L-S-DATA-EXPED ,
            :BI0005L-S-UF-EXPEDIDORA :VIND-UF-EXP )
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.GE_DOC_CLIENTE (COD_CLIENTE , COD_IDENTIFICACAO , NOM_ORGAO_EXP , DTH_EXPEDICAO , COD_UF) VALUES ({FieldThreatment(this.WS_COD_CLI_ATU)} , {FieldThreatment(this.BI0005L_S_NUM_IDENT)} , {FieldThreatment(this.BI0005L_S_ORGAO_EXPED)} , {FieldThreatment(this.BI0005L_S_DATA_EXPED)} ,  {FieldThreatment((this.VIND_UF_EXP?.ToInt() == -1 ? null : this.BI0005L_S_UF_EXPEDIDORA))} )";

            return query;
        }
        public string WS_COD_CLI_ATU { get; set; }
        public string BI0005L_S_NUM_IDENT { get; set; }
        public string BI0005L_S_ORGAO_EXPED { get; set; }
        public string BI0005L_S_DATA_EXPED { get; set; }
        public string BI0005L_S_UF_EXPEDIDORA { get; set; }
        public string VIND_UF_EXP { get; set; }

        public static void Execute(M_19300_00_INS_GE_DOC_DB_INSERT_1_Insert1 m_19300_00_INS_GE_DOC_DB_INSERT_1_Insert1)
        {
            var ths = m_19300_00_INS_GE_DOC_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_19300_00_INS_GE_DOC_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}