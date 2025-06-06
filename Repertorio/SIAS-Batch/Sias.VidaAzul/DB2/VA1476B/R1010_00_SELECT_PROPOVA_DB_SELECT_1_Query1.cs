using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA1476B
{
    public class R1010_00_SELECT_PROPOVA_DB_SELECT_1_Query1 : QueryBasis<R1010_00_SELECT_PROPOVA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_APOLICE ,
            COD_SUBGRUPO ,
            DATA_QUITACAO ,
            NUM_CERTIFICADO ,
            COD_CLIENTE ,
            COD_PRODUTO ,
            OCOREND
            INTO :PROPOVA-NUM-APOLICE ,
            :PROPOVA-COD-SUBGRUPO ,
            :PROPOVA-DATA-QUITACAO ,
            :PROPOVA-NUM-CERTIFICADO ,
            :PROPOVA-COD-CLIENTE ,
            :PROPOVA-COD-PRODUTO ,
            :PROPOVA-OCOREND
            FROM SEGUROS.PROPOSTAS_VA
            WHERE NUM_CERTIFICADO = :MOVIMVGA-NUM-CERTIFICADO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_APOLICE 
							,
											COD_SUBGRUPO 
							,
											DATA_QUITACAO 
							,
											NUM_CERTIFICADO 
							,
											COD_CLIENTE 
							,
											COD_PRODUTO 
							,
											OCOREND
											FROM SEGUROS.PROPOSTAS_VA
											WHERE NUM_CERTIFICADO = '{this.MOVIMVGA_NUM_CERTIFICADO}'
											WITH UR";

            return query;
        }
        public string PROPOVA_NUM_APOLICE { get; set; }
        public string PROPOVA_COD_SUBGRUPO { get; set; }
        public string PROPOVA_DATA_QUITACAO { get; set; }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }
        public string PROPOVA_COD_CLIENTE { get; set; }
        public string PROPOVA_COD_PRODUTO { get; set; }
        public string PROPOVA_OCOREND { get; set; }
        public string MOVIMVGA_NUM_CERTIFICADO { get; set; }

        public static R1010_00_SELECT_PROPOVA_DB_SELECT_1_Query1 Execute(R1010_00_SELECT_PROPOVA_DB_SELECT_1_Query1 r1010_00_SELECT_PROPOVA_DB_SELECT_1_Query1)
        {
            var ths = r1010_00_SELECT_PROPOVA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1010_00_SELECT_PROPOVA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1010_00_SELECT_PROPOVA_DB_SELECT_1_Query1();
            var i = 0;
            dta.PROPOVA_NUM_APOLICE = result[i++].Value?.ToString();
            dta.PROPOVA_COD_SUBGRUPO = result[i++].Value?.ToString();
            dta.PROPOVA_DATA_QUITACAO = result[i++].Value?.ToString();
            dta.PROPOVA_NUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.PROPOVA_COD_CLIENTE = result[i++].Value?.ToString();
            dta.PROPOVA_COD_PRODUTO = result[i++].Value?.ToString();
            dta.PROPOVA_OCOREND = result[i++].Value?.ToString();
            return dta;
        }

    }
}