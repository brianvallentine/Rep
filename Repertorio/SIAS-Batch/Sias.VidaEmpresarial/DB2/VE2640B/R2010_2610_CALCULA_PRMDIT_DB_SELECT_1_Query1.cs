using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE2640B
{
    public class R2010_2610_CALCULA_PRMDIT_DB_SELECT_1_Query1 : QueryBasis<R2010_2610_CALCULA_PRMDIT_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT B.VLR_PERC_PREMIO
            INTO :VG081-VLR-PERC-PREMIO
            FROM SEGUROS.VG_PARAM_RAMO_CONJ A,
            SEGUROS.VG_PARAM_RAMO_COMP B
            WHERE A.NUM_APOLICE = :VGSOLFAT-NUM-APOLICE
            AND A.COD_SUBGRUPO = :H-CODSUBES
            AND A.DTH_INI_VIGENCIA <= :H-DTVENCTO1
            AND A.DTH_TER_VIGENCIA >= :H-DTVENCTO1
            AND B.NUM_APOLICE = A.NUM_APOLICE
            AND B.COD_SUBGRUPO = A.COD_SUBGRUPO
            AND B.RAMO_EMISSOR = A.RAMO_EMISSOR
            AND B.COD_MODALIDADE = A.COD_MODALIDADE
            AND B.DTH_INI_VIGENCIA = A.DTH_INI_VIGENCIA
            AND B.RAMO_EMISSOR = 90
            AND B.COD_MODALIDADE = 5
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT B.VLR_PERC_PREMIO
											FROM SEGUROS.VG_PARAM_RAMO_CONJ A
							,
											SEGUROS.VG_PARAM_RAMO_COMP B
											WHERE A.NUM_APOLICE = '{this.VGSOLFAT_NUM_APOLICE}'
											AND A.COD_SUBGRUPO = '{this.H_CODSUBES}'
											AND A.DTH_INI_VIGENCIA <= '{this.H_DTVENCTO1}'
											AND A.DTH_TER_VIGENCIA >= '{this.H_DTVENCTO1}'
											AND B.NUM_APOLICE = A.NUM_APOLICE
											AND B.COD_SUBGRUPO = A.COD_SUBGRUPO
											AND B.RAMO_EMISSOR = A.RAMO_EMISSOR
											AND B.COD_MODALIDADE = A.COD_MODALIDADE
											AND B.DTH_INI_VIGENCIA = A.DTH_INI_VIGENCIA
											AND B.RAMO_EMISSOR = 90
											AND B.COD_MODALIDADE = 5";

            return query;
        }
        public string VG081_VLR_PERC_PREMIO { get; set; }
        public string VGSOLFAT_NUM_APOLICE { get; set; }
        public string H_DTVENCTO1 { get; set; }
        public string H_CODSUBES { get; set; }

        public static R2010_2610_CALCULA_PRMDIT_DB_SELECT_1_Query1 Execute(R2010_2610_CALCULA_PRMDIT_DB_SELECT_1_Query1 r2010_2610_CALCULA_PRMDIT_DB_SELECT_1_Query1)
        {
            var ths = r2010_2610_CALCULA_PRMDIT_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2010_2610_CALCULA_PRMDIT_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2010_2610_CALCULA_PRMDIT_DB_SELECT_1_Query1();
            var i = 0;
            dta.VG081_VLR_PERC_PREMIO = result[i++].Value?.ToString();
            return dta;
        }

    }
}