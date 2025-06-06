using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0600B
{
    public class R0910_TRATA_INF_SICAQWEB_DB_INSERT_1_Insert1 : QueryBasis<R0910_TRATA_INF_SICAQWEB_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.PROP_FIDELIZ_COMP VALUES
            (:DCLPROP-FIDELIZ-COMP.PROFIDCO-NUM-IDENTIFICACAO,
            :DCLPROP-FIDELIZ-COMP.PROFIDCO-INFORMACAO-COMPL,
            :DCLPROP-FIDELIZ-COMP.PROFIDCO-COD-USUARIO,
            CURRENT TIMESTAMP,
            :DCLPROP-FIDELIZ-COMP.PROFIDCO-IND-TP-INFORMACAO)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.PROP_FIDELIZ_COMP VALUES ({FieldThreatment(this.PROFIDCO_NUM_IDENTIFICACAO)}, {FieldThreatment(this.PROFIDCO_INFORMACAO_COMPL)}, {FieldThreatment(this.PROFIDCO_COD_USUARIO)}, CURRENT TIMESTAMP, {FieldThreatment(this.PROFIDCO_IND_TP_INFORMACAO)})";

            return query;
        }
        public string PROFIDCO_NUM_IDENTIFICACAO { get; set; }
        public string PROFIDCO_INFORMACAO_COMPL { get; set; }
        public string PROFIDCO_COD_USUARIO { get; set; }
        public string PROFIDCO_IND_TP_INFORMACAO { get; set; }

        public static void Execute(R0910_TRATA_INF_SICAQWEB_DB_INSERT_1_Insert1 r0910_TRATA_INF_SICAQWEB_DB_INSERT_1_Insert1)
        {
            var ths = r0910_TRATA_INF_SICAQWEB_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0910_TRATA_INF_SICAQWEB_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}