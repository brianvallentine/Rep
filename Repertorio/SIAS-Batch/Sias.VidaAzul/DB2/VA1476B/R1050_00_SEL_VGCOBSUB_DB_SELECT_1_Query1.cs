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
    public class R1050_00_SEL_VGCOBSUB_DB_SELECT_1_Query1 : QueryBasis<R1050_00_SEL_VGCOBSUB_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_COBERTURA
            INTO :VGCOBSUB-COD-COBERTURA
            FROM SEGUROS.VG_COBERTURAS_SUBG
            WHERE NUM_APOLICE = :MOVIMVGA-NUM-APOLICE
            AND COD_SUBGRUPO = :MOVIMVGA-COD-SUBGRUPO
            AND ( COD_COBERTURA = 25
            OR COD_COBERTURA = 36 )
            AND SIT_COBERTURA = 0
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_COBERTURA
											FROM SEGUROS.VG_COBERTURAS_SUBG
											WHERE NUM_APOLICE = '{this.MOVIMVGA_NUM_APOLICE}'
											AND COD_SUBGRUPO = '{this.MOVIMVGA_COD_SUBGRUPO}'
											AND ( COD_COBERTURA = 25
											OR COD_COBERTURA = 36 )
											AND SIT_COBERTURA = 0";

            return query;
        }
        public string VGCOBSUB_COD_COBERTURA { get; set; }
        public string MOVIMVGA_COD_SUBGRUPO { get; set; }
        public string MOVIMVGA_NUM_APOLICE { get; set; }

        public static R1050_00_SEL_VGCOBSUB_DB_SELECT_1_Query1 Execute(R1050_00_SEL_VGCOBSUB_DB_SELECT_1_Query1 r1050_00_SEL_VGCOBSUB_DB_SELECT_1_Query1)
        {
            var ths = r1050_00_SEL_VGCOBSUB_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1050_00_SEL_VGCOBSUB_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1050_00_SEL_VGCOBSUB_DB_SELECT_1_Query1();
            var i = 0;
            dta.VGCOBSUB_COD_COBERTURA = result[i++].Value?.ToString();
            return dta;
        }

    }
}