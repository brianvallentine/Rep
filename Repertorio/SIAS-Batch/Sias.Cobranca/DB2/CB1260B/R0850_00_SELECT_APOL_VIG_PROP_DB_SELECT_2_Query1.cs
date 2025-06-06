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
    public class R0850_00_SELECT_APOL_VIG_PROP_DB_SELECT_2_Query1 : QueryBasis<R0850_00_SELECT_APOL_VIG_PROP_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_APOLICE
            ,NUM_ENDOSSO
            ,NUM_PARCELA
            ,SITUACAO
            INTO :CBMALPAR-NUM-APOLICE
            ,:CBMALPAR-NUM-ENDOSSO
            ,:CBMALPAR-NUM-PARCELA
            ,:CBMALPAR-SITUACAO
            FROM SEGUROS.CB_MALA_PARCATRASO
            WHERE NUM_APOLICE = :PARCELAS-NUM-APOLICE
            AND NUM_ENDOSSO = :PARCELAS-NUM-ENDOSSO
            AND NUM_PARCELA = :PARCELAS-NUM-PARCELA
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_APOLICE
											,NUM_ENDOSSO
											,NUM_PARCELA
											,SITUACAO
											FROM SEGUROS.CB_MALA_PARCATRASO
											WHERE NUM_APOLICE = '{this.PARCELAS_NUM_APOLICE}'
											AND NUM_ENDOSSO = '{this.PARCELAS_NUM_ENDOSSO}'
											AND NUM_PARCELA = '{this.PARCELAS_NUM_PARCELA}'
											WITH UR";

            return query;
        }
        public string CBMALPAR_NUM_APOLICE { get; set; }
        public string CBMALPAR_NUM_ENDOSSO { get; set; }
        public string CBMALPAR_NUM_PARCELA { get; set; }
        public string CBMALPAR_SITUACAO { get; set; }
        public string PARCELAS_NUM_APOLICE { get; set; }
        public string PARCELAS_NUM_ENDOSSO { get; set; }
        public string PARCELAS_NUM_PARCELA { get; set; }

        public static R0850_00_SELECT_APOL_VIG_PROP_DB_SELECT_2_Query1 Execute(R0850_00_SELECT_APOL_VIG_PROP_DB_SELECT_2_Query1 r0850_00_SELECT_APOL_VIG_PROP_DB_SELECT_2_Query1)
        {
            var ths = r0850_00_SELECT_APOL_VIG_PROP_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0850_00_SELECT_APOL_VIG_PROP_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0850_00_SELECT_APOL_VIG_PROP_DB_SELECT_2_Query1();
            var i = 0;
            dta.CBMALPAR_NUM_APOLICE = result[i++].Value?.ToString();
            dta.CBMALPAR_NUM_ENDOSSO = result[i++].Value?.ToString();
            dta.CBMALPAR_NUM_PARCELA = result[i++].Value?.ToString();
            dta.CBMALPAR_SITUACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}