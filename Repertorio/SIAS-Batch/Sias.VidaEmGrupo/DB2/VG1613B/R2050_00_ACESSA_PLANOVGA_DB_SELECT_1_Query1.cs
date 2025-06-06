using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1613B
{
    public class R2050_00_ACESSA_PLANOVGA_DB_SELECT_1_Query1 : QueryBasis<R2050_00_ACESSA_PLANOVGA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_PLANO,
            DATA_INIVIGENCIA,
            IMP_MORNATU,
            IMP_MORACID,
            IMP_INVPERM,
            IMP_AMDS,
            IMP_DH,
            IMP_DIT
            INTO :PLANOVGA-COD-PLANO,
            :PLANOVGA-DATA-INIVIGENCIA,
            :PLANOVGA-IMP-MORNATU,
            :PLANOVGA-IMP-MORACID,
            :PLANOVGA-IMP-INVPERM,
            :PLANOVGA-IMP-AMDS,
            :PLANOVGA-IMP-DH,
            :PLANOVGA-IMP-DIT
            FROM SEGUROS.PLANOS_VGAP
            WHERE NUM_APOLICE = :SUBGVGAP-NUM-APOLICE
            AND COD_SUBGRUPO = :SUBGVGAP-COD-SUBGRUPO
            AND DATA_TERVIGENCIA IN ( '1999-12-31' , '9999-12-31' )
            AND SIT_REGISTRO = '0'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_PLANO
							,
											DATA_INIVIGENCIA
							,
											IMP_MORNATU
							,
											IMP_MORACID
							,
											IMP_INVPERM
							,
											IMP_AMDS
							,
											IMP_DH
							,
											IMP_DIT
											FROM SEGUROS.PLANOS_VGAP
											WHERE NUM_APOLICE = '{this.SUBGVGAP_NUM_APOLICE}'
											AND COD_SUBGRUPO = '{this.SUBGVGAP_COD_SUBGRUPO}'
											AND DATA_TERVIGENCIA IN ( '1999-12-31' 
							, '9999-12-31' )
											AND SIT_REGISTRO = '0'
											WITH UR";

            return query;
        }
        public string PLANOVGA_COD_PLANO { get; set; }
        public string PLANOVGA_DATA_INIVIGENCIA { get; set; }
        public string PLANOVGA_IMP_MORNATU { get; set; }
        public string PLANOVGA_IMP_MORACID { get; set; }
        public string PLANOVGA_IMP_INVPERM { get; set; }
        public string PLANOVGA_IMP_AMDS { get; set; }
        public string PLANOVGA_IMP_DH { get; set; }
        public string PLANOVGA_IMP_DIT { get; set; }
        public string SUBGVGAP_COD_SUBGRUPO { get; set; }
        public string SUBGVGAP_NUM_APOLICE { get; set; }

        public static R2050_00_ACESSA_PLANOVGA_DB_SELECT_1_Query1 Execute(R2050_00_ACESSA_PLANOVGA_DB_SELECT_1_Query1 r2050_00_ACESSA_PLANOVGA_DB_SELECT_1_Query1)
        {
            var ths = r2050_00_ACESSA_PLANOVGA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2050_00_ACESSA_PLANOVGA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2050_00_ACESSA_PLANOVGA_DB_SELECT_1_Query1();
            var i = 0;
            dta.PLANOVGA_COD_PLANO = result[i++].Value?.ToString();
            dta.PLANOVGA_DATA_INIVIGENCIA = result[i++].Value?.ToString();
            dta.PLANOVGA_IMP_MORNATU = result[i++].Value?.ToString();
            dta.PLANOVGA_IMP_MORACID = result[i++].Value?.ToString();
            dta.PLANOVGA_IMP_INVPERM = result[i++].Value?.ToString();
            dta.PLANOVGA_IMP_AMDS = result[i++].Value?.ToString();
            dta.PLANOVGA_IMP_DH = result[i++].Value?.ToString();
            dta.PLANOVGA_IMP_DIT = result[i++].Value?.ToString();
            return dta;
        }

    }
}