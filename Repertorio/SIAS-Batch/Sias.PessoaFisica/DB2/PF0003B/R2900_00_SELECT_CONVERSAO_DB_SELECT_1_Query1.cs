using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0003B
{
    public class R2900_00_SELECT_CONVERSAO_DB_SELECT_1_Query1 : QueryBasis<R2900_00_SELECT_CONVERSAO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_SICOB,
            AGEPGTO,
            DATA_QUITACAO,
            VAL_RCAP,
            COD_USUARIO
            INTO :CONVSICOB-NR-SICOB,
            :CONVSICOB-AGEPGTO,
            :CONVSICOB-DTQITBCO,
            :CONVSICOB-VAL-RCAP,
            :CONVSICOB-COD-USUARIO
            FROM SEGUROS.CONVERSAO_SICOB
            WHERE NUM_PROPOSTA_SIVPF = :V0FILT-NUMSIVPF
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
											FROM SEGUROS.CONVERSAO_SICOB
											WHERE NUM_PROPOSTA_SIVPF = '{this.V0FILT_NUMSIVPF}'
											WITH UR";

            return query;
        }
        public string CONVSICOB_NR_SICOB { get; set; }
        public string CONVSICOB_AGEPGTO { get; set; }
        public string CONVSICOB_DTQITBCO { get; set; }
        public string CONVSICOB_VAL_RCAP { get; set; }
        public string CONVSICOB_COD_USUARIO { get; set; }
        public string V0FILT_NUMSIVPF { get; set; }

        public static R2900_00_SELECT_CONVERSAO_DB_SELECT_1_Query1 Execute(R2900_00_SELECT_CONVERSAO_DB_SELECT_1_Query1 r2900_00_SELECT_CONVERSAO_DB_SELECT_1_Query1)
        {
            var ths = r2900_00_SELECT_CONVERSAO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2900_00_SELECT_CONVERSAO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2900_00_SELECT_CONVERSAO_DB_SELECT_1_Query1();
            var i = 0;
            dta.CONVSICOB_NR_SICOB = result[i++].Value?.ToString();
            dta.CONVSICOB_AGEPGTO = result[i++].Value?.ToString();
            dta.CONVSICOB_DTQITBCO = result[i++].Value?.ToString();
            dta.CONVSICOB_VAL_RCAP = result[i++].Value?.ToString();
            dta.CONVSICOB_COD_USUARIO = result[i++].Value?.ToString();
            return dta;
        }

    }
}