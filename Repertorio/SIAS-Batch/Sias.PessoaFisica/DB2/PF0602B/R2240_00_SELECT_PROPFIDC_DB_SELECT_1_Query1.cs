using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0602B
{
    public class R2240_00_SELECT_PROPFIDC_DB_SELECT_1_Query1 : QueryBasis<R2240_00_SELECT_PROPFIDC_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT INFORMACAO_COMPL
            INTO :DCLPROP-FIDELIZ-COMP.PROFIDCO-INFORMACAO-COMPL
            FROM SEGUROS.PROP_FIDELIZ_COMP
            WHERE NUM_IDENTIFICACAO =
            :DCLPROPOSTA-FIDELIZ.NUM-IDENTIFICACAO
            AND IND_TP_INFORMACAO =
            :DCLPROP-FIDELIZ-COMP.PROFIDCO-IND-TP-INFORMACAO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT INFORMACAO_COMPL
											FROM SEGUROS.PROP_FIDELIZ_COMP
											WHERE NUM_IDENTIFICACAO =
											'{this.NUM_IDENTIFICACAO}'
											AND IND_TP_INFORMACAO =
											'{this.PROFIDCO_IND_TP_INFORMACAO}'";

            return query;
        }
        public string PROFIDCO_INFORMACAO_COMPL { get; set; }
        public string PROFIDCO_IND_TP_INFORMACAO { get; set; }
        public string NUM_IDENTIFICACAO { get; set; }

        public static R2240_00_SELECT_PROPFIDC_DB_SELECT_1_Query1 Execute(R2240_00_SELECT_PROPFIDC_DB_SELECT_1_Query1 r2240_00_SELECT_PROPFIDC_DB_SELECT_1_Query1)
        {
            var ths = r2240_00_SELECT_PROPFIDC_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2240_00_SELECT_PROPFIDC_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2240_00_SELECT_PROPFIDC_DB_SELECT_1_Query1();
            var i = 0;
            dta.PROFIDCO_INFORMACAO_COMPL = result[i++].Value?.ToString();
            return dta;
        }

    }
}