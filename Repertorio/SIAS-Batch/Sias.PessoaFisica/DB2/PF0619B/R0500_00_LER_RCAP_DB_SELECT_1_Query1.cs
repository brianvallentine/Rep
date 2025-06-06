using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0619B
{
    public class R0500_00_LER_RCAP_DB_SELECT_1_Query1 : QueryBasis<R0500_00_LER_RCAP_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            COD_FONTE,
            NUM_RCAP,
            NUM_PROPOSTA,
            VAL_RCAP,
            VAL_RCAP_PRINCIPAL,
            DATA_CADASTRAMENTO,
            DATA_MOVIMENTO,
            SIT_REGISTRO,
            COD_OPERACAO,
            NUM_TITULO
            INTO
            :DCLRCAPS.RCAPS-COD-FONTE,
            :DCLRCAPS.RCAPS-NUM-RCAP,
            :DCLRCAPS.RCAPS-NUM-PROPOSTA,
            :DCLRCAPS.RCAPS-VAL-RCAP,
            :DCLRCAPS.RCAPS-VAL-RCAP-PRINCIPAL,
            :DCLRCAPS.RCAPS-DATA-CADASTRAMENTO,
            :DCLRCAPS.RCAPS-DATA-MOVIMENTO,
            :DCLRCAPS.RCAPS-SIT-REGISTRO,
            :DCLRCAPS.RCAPS-COD-OPERACAO,
            :DCLRCAPS.RCAPS-NUM-TITULO
            FROM SEGUROS.RCAPS
            WHERE NUM_CERTIFICADO = :DCLRCAPS.RCAPS-NUM-CERTIFICADO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											COD_FONTE
							,
											NUM_RCAP
							,
											NUM_PROPOSTA
							,
											VAL_RCAP
							,
											VAL_RCAP_PRINCIPAL
							,
											DATA_CADASTRAMENTO
							,
											DATA_MOVIMENTO
							,
											SIT_REGISTRO
							,
											COD_OPERACAO
							,
											NUM_TITULO
											FROM SEGUROS.RCAPS
											WHERE NUM_CERTIFICADO = '{this.RCAPS_NUM_CERTIFICADO}'
											WITH UR";

            return query;
        }
        public string RCAPS_COD_FONTE { get; set; }
        public string RCAPS_NUM_RCAP { get; set; }
        public string RCAPS_NUM_PROPOSTA { get; set; }
        public string RCAPS_VAL_RCAP { get; set; }
        public string RCAPS_VAL_RCAP_PRINCIPAL { get; set; }
        public string RCAPS_DATA_CADASTRAMENTO { get; set; }
        public string RCAPS_DATA_MOVIMENTO { get; set; }
        public string RCAPS_SIT_REGISTRO { get; set; }
        public string RCAPS_COD_OPERACAO { get; set; }
        public string RCAPS_NUM_TITULO { get; set; }
        public string RCAPS_NUM_CERTIFICADO { get; set; }

        public static R0500_00_LER_RCAP_DB_SELECT_1_Query1 Execute(R0500_00_LER_RCAP_DB_SELECT_1_Query1 r0500_00_LER_RCAP_DB_SELECT_1_Query1)
        {
            var ths = r0500_00_LER_RCAP_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0500_00_LER_RCAP_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0500_00_LER_RCAP_DB_SELECT_1_Query1();
            var i = 0;
            dta.RCAPS_COD_FONTE = result[i++].Value?.ToString();
            dta.RCAPS_NUM_RCAP = result[i++].Value?.ToString();
            dta.RCAPS_NUM_PROPOSTA = result[i++].Value?.ToString();
            dta.RCAPS_VAL_RCAP = result[i++].Value?.ToString();
            dta.RCAPS_VAL_RCAP_PRINCIPAL = result[i++].Value?.ToString();
            dta.RCAPS_DATA_CADASTRAMENTO = result[i++].Value?.ToString();
            dta.RCAPS_DATA_MOVIMENTO = result[i++].Value?.ToString();
            dta.RCAPS_SIT_REGISTRO = result[i++].Value?.ToString();
            dta.RCAPS_COD_OPERACAO = result[i++].Value?.ToString();
            dta.RCAPS_NUM_TITULO = result[i++].Value?.ToString();
            return dta;
        }

    }
}