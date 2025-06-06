using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB1260B
{
    public class R0850_00_SELECT_APOL_VIG_PROP_DB_SELECT_1_Query1 : QueryBasis<R0850_00_SELECT_APOL_VIG_PROP_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_APOLICE
            ,NUM_ENDOSSO
            ,NUM_PARCELA
            ,DATA_MOVIMENTO
            ,DATA_FIM_VIG_PROP
            ,DATA_CANCELAMENTO
            ,SITUACAO
            INTO :CBAPOVIG-NUM-APOLICE
            ,:CBAPOVIG-NUM-ENDOSSO
            ,:CBAPOVIG-NUM-PARCELA
            ,:CBAPOVIG-DATA-MOVIMENTO
            ,:CBAPOVIG-DATA-FIM-VIG-PROP
            ,:CBAPOVIG-DATA-CANCELAMENTO
            ,:CBAPOVIG-SITUACAO
            FROM SEGUROS.CB_APOLICE_VIGPROP
            WHERE NUM_APOLICE = :PARCELAS-NUM-APOLICE
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_APOLICE
											,NUM_ENDOSSO
											,NUM_PARCELA
											,DATA_MOVIMENTO
											,DATA_FIM_VIG_PROP
											,DATA_CANCELAMENTO
											,SITUACAO
											FROM SEGUROS.CB_APOLICE_VIGPROP
											WHERE NUM_APOLICE = '{this.PARCELAS_NUM_APOLICE}'
											WITH UR";

            return query;
        }
        public string CBAPOVIG_NUM_APOLICE { get; set; }
        public string CBAPOVIG_NUM_ENDOSSO { get; set; }
        public string CBAPOVIG_NUM_PARCELA { get; set; }
        public string CBAPOVIG_DATA_MOVIMENTO { get; set; }
        public string CBAPOVIG_DATA_FIM_VIG_PROP { get; set; }
        public string CBAPOVIG_DATA_CANCELAMENTO { get; set; }
        public string CBAPOVIG_SITUACAO { get; set; }
        public string PARCELAS_NUM_APOLICE { get; set; }

        public static R0850_00_SELECT_APOL_VIG_PROP_DB_SELECT_1_Query1 Execute(R0850_00_SELECT_APOL_VIG_PROP_DB_SELECT_1_Query1 r0850_00_SELECT_APOL_VIG_PROP_DB_SELECT_1_Query1)
        {
            var ths = r0850_00_SELECT_APOL_VIG_PROP_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0850_00_SELECT_APOL_VIG_PROP_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0850_00_SELECT_APOL_VIG_PROP_DB_SELECT_1_Query1();
            var i = 0;
            dta.CBAPOVIG_NUM_APOLICE = result[i++].Value?.ToString();
            dta.CBAPOVIG_NUM_ENDOSSO = result[i++].Value?.ToString();
            dta.CBAPOVIG_NUM_PARCELA = result[i++].Value?.ToString();
            dta.CBAPOVIG_DATA_MOVIMENTO = result[i++].Value?.ToString();
            dta.CBAPOVIG_DATA_FIM_VIG_PROP = result[i++].Value?.ToString();
            dta.CBAPOVIG_DATA_CANCELAMENTO = result[i++].Value?.ToString();
            dta.CBAPOVIG_SITUACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}