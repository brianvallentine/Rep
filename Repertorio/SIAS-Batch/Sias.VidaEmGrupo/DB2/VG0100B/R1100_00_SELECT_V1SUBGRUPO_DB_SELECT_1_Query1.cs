using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0100B
{
    public class R1100_00_SELECT_V1SUBGRUPO_DB_SELECT_1_Query1 : QueryBasis<R1100_00_SELECT_V1SUBGRUPO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT TIPO_FATURAMENTO ,
            COD_FONTE ,
            COD_SUBGRUPO ,
            OCORR_END_COBRAN ,
            BCO_COBRANCA ,
            AGE_COBRANCA ,
            DAC_COBRANCA ,
            PERI_FATURAMENTO ,
            DTTERVIG ,
            VALUE(IND_IOF, 'S' )
            INTO :V1SUBG-TIPO-FAT ,
            :V1SUBG-COD-FONTE ,
            :V1SUBG-COD-SUBG ,
            :V1SUBG-END-COB ,
            :V1SUBG-BCO-COB ,
            :V1SUBG-AGE-COB ,
            :V1SUBG-DAC-COB ,
            :V1SUBG-PERI-FATUR ,
            :V1SUBG-DTTERVIG ,
            :V1SUBG-IND-IOF
            FROM SEGUROS.V1SUBGRUPO
            WHERE NUM_APOLICE = :V1SOLF-NUM-APOL
            AND COD_SUBGRUPO = :V1SOLF-COD-SUBG
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT TIPO_FATURAMENTO 
							,
											COD_FONTE 
							,
											COD_SUBGRUPO 
							,
											OCORR_END_COBRAN 
							,
											BCO_COBRANCA 
							,
											AGE_COBRANCA 
							,
											DAC_COBRANCA 
							,
											PERI_FATURAMENTO 
							,
											DTTERVIG 
							,
											VALUE(IND_IOF
							, 'S' )
											FROM SEGUROS.V1SUBGRUPO
											WHERE NUM_APOLICE = '{this.V1SOLF_NUM_APOL}'
											AND COD_SUBGRUPO = '{this.V1SOLF_COD_SUBG}'";

            return query;
        }
        public string V1SUBG_TIPO_FAT { get; set; }
        public string V1SUBG_COD_FONTE { get; set; }
        public string V1SUBG_COD_SUBG { get; set; }
        public string V1SUBG_END_COB { get; set; }
        public string V1SUBG_BCO_COB { get; set; }
        public string V1SUBG_AGE_COB { get; set; }
        public string V1SUBG_DAC_COB { get; set; }
        public string V1SUBG_PERI_FATUR { get; set; }
        public string V1SUBG_DTTERVIG { get; set; }
        public string V1SUBG_IND_IOF { get; set; }
        public string V1SOLF_NUM_APOL { get; set; }
        public string V1SOLF_COD_SUBG { get; set; }

        public static R1100_00_SELECT_V1SUBGRUPO_DB_SELECT_1_Query1 Execute(R1100_00_SELECT_V1SUBGRUPO_DB_SELECT_1_Query1 r1100_00_SELECT_V1SUBGRUPO_DB_SELECT_1_Query1)
        {
            var ths = r1100_00_SELECT_V1SUBGRUPO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1100_00_SELECT_V1SUBGRUPO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1100_00_SELECT_V1SUBGRUPO_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1SUBG_TIPO_FAT = result[i++].Value?.ToString();
            dta.V1SUBG_COD_FONTE = result[i++].Value?.ToString();
            dta.V1SUBG_COD_SUBG = result[i++].Value?.ToString();
            dta.V1SUBG_END_COB = result[i++].Value?.ToString();
            dta.V1SUBG_BCO_COB = result[i++].Value?.ToString();
            dta.V1SUBG_AGE_COB = result[i++].Value?.ToString();
            dta.V1SUBG_DAC_COB = result[i++].Value?.ToString();
            dta.V1SUBG_PERI_FATUR = result[i++].Value?.ToString();
            dta.V1SUBG_DTTERVIG = result[i++].Value?.ToString();
            dta.V1SUBG_IND_IOF = result[i++].Value?.ToString();
            return dta;
        }

    }
}