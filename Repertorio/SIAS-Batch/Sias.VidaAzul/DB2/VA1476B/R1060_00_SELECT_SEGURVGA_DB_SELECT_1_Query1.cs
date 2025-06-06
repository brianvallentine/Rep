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
    public class R1060_00_SELECT_SEGURVGA_DB_SELECT_1_Query1 : QueryBasis<R1060_00_SELECT_SEGURVGA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_APOLICE ,
            COD_SUBGRUPO ,
            DATA_INIVIGENCIA ,
            NUM_CERTIFICADO ,
            COD_CLIENTE ,
            OCORR_ENDERECO ,
            IDE_SEXO
            INTO :SEGURVGA-NUM-APOLICE,
            :SEGURVGA-COD-SUBGRUPO,
            :SEGURVGA-DATA-INIVIGENCIA,
            :SEGURVGA-NUM-CERTIFICADO,
            :SEGURVGA-COD-CLIENTE,
            :SEGURVGA-OCORR-ENDERECO,
            :SEGURVGA-IDE-SEXO
            FROM SEGUROS.SEGURADOS_VGAP
            WHERE NUM_CERTIFICADO = :MOVIMVGA-NUM-CERTIFICADO
            AND TIPO_SEGURADO = '1'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_APOLICE 
							,
											COD_SUBGRUPO 
							,
											DATA_INIVIGENCIA 
							,
											NUM_CERTIFICADO 
							,
											COD_CLIENTE 
							,
											OCORR_ENDERECO 
							,
											IDE_SEXO
											FROM SEGUROS.SEGURADOS_VGAP
											WHERE NUM_CERTIFICADO = '{this.MOVIMVGA_NUM_CERTIFICADO}'
											AND TIPO_SEGURADO = '1'
											WITH UR";

            return query;
        }
        public string SEGURVGA_NUM_APOLICE { get; set; }
        public string SEGURVGA_COD_SUBGRUPO { get; set; }
        public string SEGURVGA_DATA_INIVIGENCIA { get; set; }
        public string SEGURVGA_NUM_CERTIFICADO { get; set; }
        public string SEGURVGA_COD_CLIENTE { get; set; }
        public string SEGURVGA_OCORR_ENDERECO { get; set; }
        public string SEGURVGA_IDE_SEXO { get; set; }
        public string MOVIMVGA_NUM_CERTIFICADO { get; set; }

        public static R1060_00_SELECT_SEGURVGA_DB_SELECT_1_Query1 Execute(R1060_00_SELECT_SEGURVGA_DB_SELECT_1_Query1 r1060_00_SELECT_SEGURVGA_DB_SELECT_1_Query1)
        {
            var ths = r1060_00_SELECT_SEGURVGA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1060_00_SELECT_SEGURVGA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1060_00_SELECT_SEGURVGA_DB_SELECT_1_Query1();
            var i = 0;
            dta.SEGURVGA_NUM_APOLICE = result[i++].Value?.ToString();
            dta.SEGURVGA_COD_SUBGRUPO = result[i++].Value?.ToString();
            dta.SEGURVGA_DATA_INIVIGENCIA = result[i++].Value?.ToString();
            dta.SEGURVGA_NUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.SEGURVGA_COD_CLIENTE = result[i++].Value?.ToString();
            dta.SEGURVGA_OCORR_ENDERECO = result[i++].Value?.ToString();
            dta.SEGURVGA_IDE_SEXO = result[i++].Value?.ToString();
            return dta;
        }

    }
}