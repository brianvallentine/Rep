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
    public class R1040_00_SELECT_BILHETE_DB_SELECT_1_Query1 : QueryBasis<R1040_00_SELECT_BILHETE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_BILHETE ,
            NUM_APOLICE ,
            DATA_QUITACAO ,
            COD_CLIENTE ,
            OCORR_ENDERECO
            INTO :BILHETE-NUM-BILHETE ,
            :BILHETE-NUM-APOLICE ,
            :BILHETE-DATA-QUITACAO ,
            :BILHETE-COD-CLIENTE ,
            :BILHETE-OCORR-ENDERECO
            FROM
            SEGUROS.BILHETE
            WHERE NUM_BILHETE = :MOVIMVGA-NUM-CERTIFICADO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_BILHETE 
							,
											NUM_APOLICE 
							,
											DATA_QUITACAO 
							,
											COD_CLIENTE 
							,
											OCORR_ENDERECO
											FROM
											SEGUROS.BILHETE
											WHERE NUM_BILHETE = '{this.MOVIMVGA_NUM_CERTIFICADO}'";

            return query;
        }
        public string BILHETE_NUM_BILHETE { get; set; }
        public string BILHETE_NUM_APOLICE { get; set; }
        public string BILHETE_DATA_QUITACAO { get; set; }
        public string BILHETE_COD_CLIENTE { get; set; }
        public string BILHETE_OCORR_ENDERECO { get; set; }
        public string MOVIMVGA_NUM_CERTIFICADO { get; set; }

        public static R1040_00_SELECT_BILHETE_DB_SELECT_1_Query1 Execute(R1040_00_SELECT_BILHETE_DB_SELECT_1_Query1 r1040_00_SELECT_BILHETE_DB_SELECT_1_Query1)
        {
            var ths = r1040_00_SELECT_BILHETE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1040_00_SELECT_BILHETE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1040_00_SELECT_BILHETE_DB_SELECT_1_Query1();
            var i = 0;
            dta.BILHETE_NUM_BILHETE = result[i++].Value?.ToString();
            dta.BILHETE_NUM_APOLICE = result[i++].Value?.ToString();
            dta.BILHETE_DATA_QUITACAO = result[i++].Value?.ToString();
            dta.BILHETE_COD_CLIENTE = result[i++].Value?.ToString();
            dta.BILHETE_OCORR_ENDERECO = result[i++].Value?.ToString();
            return dta;
        }

    }
}