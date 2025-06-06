using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG9521B
{
    public class R0050_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1 : QueryBasis<R0050_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            A.NUM_APOLICE,
            A.COD_SUBGRUPO,
            A.NUM_CERTIFICADO,
            A.NUM_ITEM,
            A.OCORR_HISTORICO,
            A.COD_CLIENTE,
            A.SIT_REGISTRO
            INTO :SEGURVGA-NUM-APOLICE,
            :SEGURVGA-COD-SUBGRUPO,
            :SEGURVGA-NUM-CERTIFICADO,
            :SEGURVGA-NUM-ITEM,
            :SEGURVGA-OCORR-HISTORICO,
            :SEGURVGA-COD-CLIENTE,
            :SEGURVGA-SIT-REGISTRO
            FROM SEGUROS.SEGURADOS_VGAP A
            WHERE A.NUM_APOLICE = :SEGURVGA-NUM-APOLICE
            AND A.COD_SUBGRUPO = :SEGURVGA-COD-SUBGRUPO
            AND A.NUM_MATRICULA = :SEGURVGA-NUM-MATRICULA
            AND A.TIPO_SEGURADO = '1'
            AND A.SIT_REGISTRO IN ( '0' , '1' )
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											A.NUM_APOLICE
							,
											A.COD_SUBGRUPO
							,
											A.NUM_CERTIFICADO
							,
											A.NUM_ITEM
							,
											A.OCORR_HISTORICO
							,
											A.COD_CLIENTE
							,
											A.SIT_REGISTRO
											FROM SEGUROS.SEGURADOS_VGAP A
											WHERE A.NUM_APOLICE = '{this.SEGURVGA_NUM_APOLICE}'
											AND A.COD_SUBGRUPO = '{this.SEGURVGA_COD_SUBGRUPO}'
											AND A.NUM_MATRICULA = '{this.SEGURVGA_NUM_MATRICULA}'
											AND A.TIPO_SEGURADO = '1'
											AND A.SIT_REGISTRO IN ( '0' 
							, '1' )";

            return query;
        }
        public string SEGURVGA_NUM_APOLICE { get; set; }
        public string SEGURVGA_COD_SUBGRUPO { get; set; }
        public string SEGURVGA_NUM_CERTIFICADO { get; set; }
        public string SEGURVGA_NUM_ITEM { get; set; }
        public string SEGURVGA_OCORR_HISTORICO { get; set; }
        public string SEGURVGA_COD_CLIENTE { get; set; }
        public string SEGURVGA_SIT_REGISTRO { get; set; }
        public string SEGURVGA_NUM_MATRICULA { get; set; }

        public static R0050_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1 Execute(R0050_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1 r0050_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1)
        {
            var ths = r0050_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0050_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0050_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1();
            var i = 0;
            dta.SEGURVGA_NUM_APOLICE = result[i++].Value?.ToString();
            dta.SEGURVGA_COD_SUBGRUPO = result[i++].Value?.ToString();
            dta.SEGURVGA_NUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.SEGURVGA_NUM_ITEM = result[i++].Value?.ToString();
            dta.SEGURVGA_OCORR_HISTORICO = result[i++].Value?.ToString();
            dta.SEGURVGA_COD_CLIENTE = result[i++].Value?.ToString();
            dta.SEGURVGA_SIT_REGISTRO = result[i++].Value?.ToString();
            return dta;
        }

    }
}