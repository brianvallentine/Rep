using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0953B
{
    public class R1210_00_SELECT_SEGURVGA_DB_SELECT_1_Query1 : QueryBasis<R1210_00_SELECT_SEGURVGA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            NUM_APOLICE,
            COD_SUBGRUPO,
            NUM_ITEM,
            NUM_CERTIFICADO,
            OCORR_HISTORICO,
            COD_CLIENTE,
            DATA_INIVIGENCIA,
            OCORR_ENDERECO,
            NUM_MATRICULA,
            AGE_COBRANCA
            INTO :SEGURVGA-NUM-APOLICE,
            :SEGURVGA-COD-SUBGRUPO,
            :SEGURVGA-NUM-ITEM,
            :SEGURVGA-NUM-CERTIFICADO,
            :SEGURVGA-OCORR-HISTORICO,
            :SEGURVGA-COD-CLIENTE,
            :SEGURVGA-DATA-INIVIGENCIA,
            :SEGURVGA-OCORR-ENDERECO,
            :SEGURVGA-NUM-MATRICULA,
            :SEGURVGA-AGE-COBRANCA
            FROM SEGUROS.SEGURADOS_VGAP
            WHERE NUM_CERTIFICADO = :V0MSIN-NRCERTIF
            AND TIPO_SEGURADO = '1'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											NUM_APOLICE
							,
											COD_SUBGRUPO
							,
											NUM_ITEM
							,
											NUM_CERTIFICADO
							,
											OCORR_HISTORICO
							,
											COD_CLIENTE
							,
											DATA_INIVIGENCIA
							,
											OCORR_ENDERECO
							,
											NUM_MATRICULA
							,
											AGE_COBRANCA
											FROM SEGUROS.SEGURADOS_VGAP
											WHERE NUM_CERTIFICADO = '{this.V0MSIN_NRCERTIF}'
											AND TIPO_SEGURADO = '1'";

            return query;
        }
        public string SEGURVGA_NUM_APOLICE { get; set; }
        public string SEGURVGA_COD_SUBGRUPO { get; set; }
        public string SEGURVGA_NUM_ITEM { get; set; }
        public string SEGURVGA_NUM_CERTIFICADO { get; set; }
        public string SEGURVGA_OCORR_HISTORICO { get; set; }
        public string SEGURVGA_COD_CLIENTE { get; set; }
        public string SEGURVGA_DATA_INIVIGENCIA { get; set; }
        public string SEGURVGA_OCORR_ENDERECO { get; set; }
        public string SEGURVGA_NUM_MATRICULA { get; set; }
        public string SEGURVGA_AGE_COBRANCA { get; set; }
        public string V0MSIN_NRCERTIF { get; set; }

        public static R1210_00_SELECT_SEGURVGA_DB_SELECT_1_Query1 Execute(R1210_00_SELECT_SEGURVGA_DB_SELECT_1_Query1 r1210_00_SELECT_SEGURVGA_DB_SELECT_1_Query1)
        {
            var ths = r1210_00_SELECT_SEGURVGA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1210_00_SELECT_SEGURVGA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1210_00_SELECT_SEGURVGA_DB_SELECT_1_Query1();
            var i = 0;
            dta.SEGURVGA_NUM_APOLICE = result[i++].Value?.ToString();
            dta.SEGURVGA_COD_SUBGRUPO = result[i++].Value?.ToString();
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