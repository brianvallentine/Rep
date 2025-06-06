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
    public class R3228_SELECT_MOVDEBCE_DB_SELECT_1_Query1 : QueryBasis<R3228_SELECT_MOVDEBCE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_PARCELA
            ,NUM_CARTAO
            INTO :MOVDEBCE-NUM-PARCELA
            ,:MOVDEBCE-NUM-CARTAO:VIND-NULL01
            FROM SEGUROS.MOVTO_DEBITOCC_CEF
            WHERE COD_CONVENIO = :MOVDEBCE-COD-CONVENIO
            AND NSAS = :MOVDEBCE-NSAS
            AND NUM_ENDOSSO = :MOVDEBCE-NUM-ENDOSSO
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_PARCELA
											,NUM_CARTAO
											FROM SEGUROS.MOVTO_DEBITOCC_CEF
											WHERE COD_CONVENIO = '{this.MOVDEBCE_COD_CONVENIO}'
											AND NSAS = '{this.MOVDEBCE_NSAS}'
											AND NUM_ENDOSSO = '{this.MOVDEBCE_NUM_ENDOSSO}'
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string MOVDEBCE_NUM_PARCELA { get; set; }
        public string MOVDEBCE_NUM_CARTAO { get; set; }
        public string VIND_NULL01 { get; set; }
        public string MOVDEBCE_COD_CONVENIO { get; set; }
        public string MOVDEBCE_NUM_ENDOSSO { get; set; }
        public string MOVDEBCE_NSAS { get; set; }

        public static R3228_SELECT_MOVDEBCE_DB_SELECT_1_Query1 Execute(R3228_SELECT_MOVDEBCE_DB_SELECT_1_Query1 r3228_SELECT_MOVDEBCE_DB_SELECT_1_Query1)
        {
            var ths = r3228_SELECT_MOVDEBCE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3228_SELECT_MOVDEBCE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3228_SELECT_MOVDEBCE_DB_SELECT_1_Query1();
            var i = 0;
            dta.MOVDEBCE_NUM_PARCELA = result[i++].Value?.ToString();
            dta.MOVDEBCE_NUM_CARTAO = result[i++].Value?.ToString();
            dta.VIND_NULL01 = string.IsNullOrWhiteSpace(dta.MOVDEBCE_NUM_CARTAO) ? "-1" : "0";
            return dta;
        }

    }
}