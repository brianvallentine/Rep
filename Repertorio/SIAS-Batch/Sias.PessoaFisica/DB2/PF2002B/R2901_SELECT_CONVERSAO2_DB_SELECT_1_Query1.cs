using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF2002B
{
    public class R2901_SELECT_CONVERSAO2_DB_SELECT_1_Query1 : QueryBasis<R2901_SELECT_CONVERSAO2_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_SICOB,
            AGEPGTO,
            DATA_QUITACAO,
            VAL_RCAP,
            COD_USUARIO,
            NUM_PROPOSTA_SIVPF
            INTO :CONVSICOB-NR-SICOB,
            :CONVSICOB-AGEPGTO,
            :CONVSICOB-DTQITBCO,
            :CONVSICOB-VAL-RCAP,
            :CONVSICOB-COD-USUARIO,
            :CONVSICOB-NUM-PROP-SIVPF
            FROM SEGUROS.CONVERSAO_SICOB
            WHERE NUM_SICOB= :V0FILT-NUMSICOB
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_SICOB
							,
											AGEPGTO
							,
											DATA_QUITACAO
							,
											VAL_RCAP
							,
											COD_USUARIO
							,
											NUM_PROPOSTA_SIVPF
											FROM SEGUROS.CONVERSAO_SICOB
											WHERE NUM_SICOB= '{this.V0FILT_NUMSICOB}'
											WITH UR";

            return query;
        }
        public string CONVSICOB_NR_SICOB { get; set; }
        public string CONVSICOB_AGEPGTO { get; set; }
        public string CONVSICOB_DTQITBCO { get; set; }
        public string CONVSICOB_VAL_RCAP { get; set; }
        public string CONVSICOB_COD_USUARIO { get; set; }
        public string CONVSICOB_NUM_PROP_SIVPF { get; set; }
        public string V0FILT_NUMSICOB { get; set; }

        public static R2901_SELECT_CONVERSAO2_DB_SELECT_1_Query1 Execute(R2901_SELECT_CONVERSAO2_DB_SELECT_1_Query1 r2901_SELECT_CONVERSAO2_DB_SELECT_1_Query1)
        {
            var ths = r2901_SELECT_CONVERSAO2_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2901_SELECT_CONVERSAO2_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2901_SELECT_CONVERSAO2_DB_SELECT_1_Query1();
            var i = 0;
            dta.CONVSICOB_NR_SICOB = result[i++].Value?.ToString();
            dta.CONVSICOB_AGEPGTO = result[i++].Value?.ToString();
            dta.CONVSICOB_DTQITBCO = result[i++].Value?.ToString();
            dta.CONVSICOB_VAL_RCAP = result[i++].Value?.ToString();
            dta.CONVSICOB_COD_USUARIO = result[i++].Value?.ToString();
            dta.CONVSICOB_NUM_PROP_SIVPF = result[i++].Value?.ToString();
            return dta;
        }

    }
}