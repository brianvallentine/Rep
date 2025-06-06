using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1625B
{
    public class R2400_00_SELECT_FXAETA_PLAVG_DB_SELECT_1_Query1 : QueryBasis<R2400_00_SELECT_FXAETA_PLAVG_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.PRM_VG + A.PRM_AP ,
            B.IMP_MORNATU
            INTO :PLANOFAI-PRM-VG,
            :PLANOVGA-IMP-MORNATU
            FROM SEGUROS.PLANOS_FAIXAETA A,
            SEGUROS.PLANOS_VGAP B,
            SEGUROS.SUBGRUPOS_VGAP C
            WHERE A.NUM_APOLICE = :PROPOVA-NUM-APOLICE
            AND B.SIT_REGISTRO = '0'
            AND C.COD_SUBGRUPO = :PROPOVA-COD-SUBGRUPO
            AND B.NUM_APOLICE = A.NUM_APOLICE
            AND B.COD_SUBGRUPO = A.COD_SUBGRUPO
            AND B.COD_PLANO = A.COD_PLANO
            AND C.NUM_APOLICE = A.NUM_APOLICE
            AND C.COD_SUBGRUPO = A.COD_SUBGRUPO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT A.PRM_VG + A.PRM_AP 
							,
											B.IMP_MORNATU
											FROM SEGUROS.PLANOS_FAIXAETA A
							,
											SEGUROS.PLANOS_VGAP B
							,
											SEGUROS.SUBGRUPOS_VGAP C
											WHERE A.NUM_APOLICE = '{this.PROPOVA_NUM_APOLICE}'
											AND B.SIT_REGISTRO = '0'
											AND C.COD_SUBGRUPO = '{this.PROPOVA_COD_SUBGRUPO}'
											AND B.NUM_APOLICE = A.NUM_APOLICE
											AND B.COD_SUBGRUPO = A.COD_SUBGRUPO
											AND B.COD_PLANO = A.COD_PLANO
											AND C.NUM_APOLICE = A.NUM_APOLICE
											AND C.COD_SUBGRUPO = A.COD_SUBGRUPO";

            return query;
        }
        public string PLANOFAI_PRM_VG { get; set; }
        public string PLANOVGA_IMP_MORNATU { get; set; }
        public string PROPOVA_COD_SUBGRUPO { get; set; }
        public string PROPOVA_NUM_APOLICE { get; set; }

        public static R2400_00_SELECT_FXAETA_PLAVG_DB_SELECT_1_Query1 Execute(R2400_00_SELECT_FXAETA_PLAVG_DB_SELECT_1_Query1 r2400_00_SELECT_FXAETA_PLAVG_DB_SELECT_1_Query1)
        {
            var ths = r2400_00_SELECT_FXAETA_PLAVG_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2400_00_SELECT_FXAETA_PLAVG_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2400_00_SELECT_FXAETA_PLAVG_DB_SELECT_1_Query1();
            var i = 0;
            dta.PLANOFAI_PRM_VG = result[i++].Value?.ToString();
            dta.PLANOVGA_IMP_MORNATU = result[i++].Value?.ToString();
            return dta;
        }

    }
}