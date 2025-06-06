using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0009B
{
    public class R1900_00_SELECT_PARCELAS_DB_SELECT_1_Query1 : QueryBasis<R1900_00_SELECT_PARCELAS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_APOLICE ,
            NUM_ENDOSSO ,
            NUM_PARCELA ,
            PRM_TARIFARIO_IX,
            VAL_DESCONTO_IX ,
            ADICIONAL_FRAC_IX
            INTO :PARCELAS-NUM-APOLICE ,
            :PARCELAS-NUM-ENDOSSO ,
            :PARCELAS-NUM-PARCELA ,
            :PARCELAS-PRM-TARIFARIO-IX,
            :PARCELAS-VAL-DESCONTO-IX ,
            :PARCELAS-ADICIONAL-FRAC-IX
            FROM SEGUROS.PARCELAS
            WHERE NUM_APOLICE = :PARCEHIS-NUM-APOLICE
            AND NUM_ENDOSSO = :PARCEHIS-NUM-ENDOSSO
            AND NUM_PARCELA = :PARCEHIS-NUM-PARCELA
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_APOLICE 
							,
											NUM_ENDOSSO 
							,
											NUM_PARCELA 
							,
											PRM_TARIFARIO_IX
							,
											VAL_DESCONTO_IX 
							,
											ADICIONAL_FRAC_IX
											FROM SEGUROS.PARCELAS
											WHERE NUM_APOLICE = '{this.PARCEHIS_NUM_APOLICE}'
											AND NUM_ENDOSSO = '{this.PARCEHIS_NUM_ENDOSSO}'
											AND NUM_PARCELA = '{this.PARCEHIS_NUM_PARCELA}'";

            return query;
        }
        public string PARCELAS_NUM_APOLICE { get; set; }
        public string PARCELAS_NUM_ENDOSSO { get; set; }
        public string PARCELAS_NUM_PARCELA { get; set; }
        public string PARCELAS_PRM_TARIFARIO_IX { get; set; }
        public string PARCELAS_VAL_DESCONTO_IX { get; set; }
        public string PARCELAS_ADICIONAL_FRAC_IX { get; set; }
        public string PARCEHIS_NUM_APOLICE { get; set; }
        public string PARCEHIS_NUM_ENDOSSO { get; set; }
        public string PARCEHIS_NUM_PARCELA { get; set; }

        public static R1900_00_SELECT_PARCELAS_DB_SELECT_1_Query1 Execute(R1900_00_SELECT_PARCELAS_DB_SELECT_1_Query1 r1900_00_SELECT_PARCELAS_DB_SELECT_1_Query1)
        {
            var ths = r1900_00_SELECT_PARCELAS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1900_00_SELECT_PARCELAS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1900_00_SELECT_PARCELAS_DB_SELECT_1_Query1();
            var i = 0;
            dta.PARCELAS_NUM_APOLICE = result[i++].Value?.ToString();
            dta.PARCELAS_NUM_ENDOSSO = result[i++].Value?.ToString();
            dta.PARCELAS_NUM_PARCELA = result[i++].Value?.ToString();
            dta.PARCELAS_PRM_TARIFARIO_IX = result[i++].Value?.ToString();
            dta.PARCELAS_VAL_DESCONTO_IX = result[i++].Value?.ToString();
            dta.PARCELAS_ADICIONAL_FRAC_IX = result[i++].Value?.ToString();
            return dta;
        }

    }
}