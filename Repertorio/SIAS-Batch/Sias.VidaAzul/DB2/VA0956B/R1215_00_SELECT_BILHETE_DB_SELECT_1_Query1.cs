using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0956B
{
    public class R1215_00_SELECT_BILHETE_DB_SELECT_1_Query1 : QueryBasis<R1215_00_SELECT_BILHETE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            NUM_APOLICE,
            0,
            NUM_BILHETE,
            0,
            COD_CLIENTE,
            DATA_QUITACAO,
            OCORR_ENDERECO,
            NUM_MATRICULA,
            AGE_COBRANCA
            INTO :SEGURVGA-NUM-APOLICE,
            :SEGURVGA-NUM-ITEM,
            :SEGURVGA-NUM-CERTIFICADO,
            :SEGURVGA-OCORR-HISTORICO,
            :SEGURVGA-COD-CLIENTE,
            :SEGURVGA-DATA-INIVIGENCIA,
            :SEGURVGA-OCORR-ENDERECO,
            :SEGURVGA-NUM-MATRICULA,
            :SEGURVGA-AGE-COBRANCA
            FROM SEGUROS.BILHETE
            WHERE NUM_APOLICE = :V0MSIN-NUM-APOL
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											NUM_APOLICE
							,
											0
							,
											NUM_BILHETE
							,
											0
							,
											COD_CLIENTE
							,
											DATA_QUITACAO
							,
											OCORR_ENDERECO
							,
											NUM_MATRICULA
							,
											AGE_COBRANCA
											FROM SEGUROS.BILHETE
											WHERE NUM_APOLICE = '{this.V0MSIN_NUM_APOL}'
											WITH UR";

            return query;
        }
        public string SEGURVGA_NUM_APOLICE { get; set; }
        public string SEGURVGA_NUM_ITEM { get; set; }
        public string SEGURVGA_NUM_CERTIFICADO { get; set; }
        public string SEGURVGA_OCORR_HISTORICO { get; set; }
        public string SEGURVGA_COD_CLIENTE { get; set; }
        public string SEGURVGA_DATA_INIVIGENCIA { get; set; }
        public string SEGURVGA_OCORR_ENDERECO { get; set; }
        public string SEGURVGA_NUM_MATRICULA { get; set; }
        public string SEGURVGA_AGE_COBRANCA { get; set; }
        public string V0MSIN_NUM_APOL { get; set; }

        public static R1215_00_SELECT_BILHETE_DB_SELECT_1_Query1 Execute(R1215_00_SELECT_BILHETE_DB_SELECT_1_Query1 r1215_00_SELECT_BILHETE_DB_SELECT_1_Query1)
        {
            var ths = r1215_00_SELECT_BILHETE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1215_00_SELECT_BILHETE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1215_00_SELECT_BILHETE_DB_SELECT_1_Query1();
            var i = 0;
            dta.SEGURVGA_NUM_APOLICE = result[i++].Value?.ToString();
            dta.SEGURVGA_NUM_ITEM = result[i++].Value?.ToString();
            dta.SEGURVGA_NUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.SEGURVGA_OCORR_HISTORICO = result[i++].Value?.ToString();
            dta.SEGURVGA_COD_CLIENTE = result[i++].Value?.ToString();
            dta.SEGURVGA_DATA_INIVIGENCIA = result[i++].Value?.ToString();
            dta.SEGURVGA_OCORR_ENDERECO = result[i++].Value?.ToString();
            dta.SEGURVGA_NUM_MATRICULA = result[i++].Value?.ToString();
            dta.SEGURVGA_AGE_COBRANCA = result[i++].Value?.ToString();
            return dta;
        }

    }
}