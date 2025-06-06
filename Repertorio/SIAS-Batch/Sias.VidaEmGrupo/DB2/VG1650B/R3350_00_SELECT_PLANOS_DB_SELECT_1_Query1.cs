using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1650B
{
    public class R3350_00_SELECT_PLANOS_DB_SELECT_1_Query1 : QueryBasis<R3350_00_SELECT_PLANOS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT IMPMORNATU,
            IMPMORACID,
            IMPINVPERM,
            IMPAMDS,
            IMPDH,
            IMPDIT,
            VLPREMIOTOT,
            PRMVG,
            PRMAP,
            QTTITCAP,
            VLTITCAP,
            VLCUSTCAP,
            IMPSEGCDG,
            VLCUSTCDG
            INTO :PLAVAVGA-IMPMORNATU,
            :PLAVAVGA-IMPMORACID,
            :PLAVAVGA-IMPINVPERM,
            :PLAVAVGA-IMPAMDS,
            :PLAVAVGA-IMPDH,
            :PLAVAVGA-IMPDIT,
            :PLAVAVGA-VLPREMIOTOT,
            :PLAVAVGA-PRMVG,
            :PLAVAVGA-PRMAP,
            :PLAVAVGA-QTTITCAP,
            :PLAVAVGA-VLTITCAP,
            :PLAVAVGA-VLCUSTCAP,
            :PLAVAVGA-IMPSEGCDG,
            :PLAVAVGA-VLCUSTCDG
            FROM SEGUROS.PLANOS_VA_VGAP
            WHERE NUM_APOLICE = :SUBGVGAP-NUM-APOLICE
            AND CODSUBES = :SUBGVGAP-COD-SUBGRUPO
            AND OPCAO_COBER = :PLAVAVGA-OPCAO-COBER
            AND :PROPOVA-IDADE BETWEEN IDADE_INICIAL
            AND IDADE_FINAL
            AND DTINIVIG <= :MOVIMVGA-DATA-MOVIMENTO
            AND DTTERVIG >= :MOVIMVGA-DATA-MOVIMENTO
            AND COD_PLANO = :PLAVAVGA-COD-PLANO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT IMPMORNATU
							,
											IMPMORACID
							,
											IMPINVPERM
							,
											IMPAMDS
							,
											IMPDH
							,
											IMPDIT
							,
											VLPREMIOTOT
							,
											PRMVG
							,
											PRMAP
							,
											QTTITCAP
							,
											VLTITCAP
							,
											VLCUSTCAP
							,
											IMPSEGCDG
							,
											VLCUSTCDG
											FROM SEGUROS.PLANOS_VA_VGAP
											WHERE NUM_APOLICE = '{this.SUBGVGAP_NUM_APOLICE}'
											AND CODSUBES = '{this.SUBGVGAP_COD_SUBGRUPO}'
											AND OPCAO_COBER = '{this.PLAVAVGA_OPCAO_COBER}'
											AND '{this.PROPOVA_IDADE}' BETWEEN IDADE_INICIAL
											AND IDADE_FINAL
											AND DTINIVIG <= '{this.MOVIMVGA_DATA_MOVIMENTO}'
											AND DTTERVIG >= '{this.MOVIMVGA_DATA_MOVIMENTO}'
											AND COD_PLANO = '{this.PLAVAVGA_COD_PLANO}'";

            return query;
        }
        public string PLAVAVGA_IMPMORNATU { get; set; }
        public string PLAVAVGA_IMPMORACID { get; set; }
        public string PLAVAVGA_IMPINVPERM { get; set; }
        public string PLAVAVGA_IMPAMDS { get; set; }
        public string PLAVAVGA_IMPDH { get; set; }
        public string PLAVAVGA_IMPDIT { get; set; }
        public string PLAVAVGA_VLPREMIOTOT { get; set; }
        public string PLAVAVGA_PRMVG { get; set; }
        public string PLAVAVGA_PRMAP { get; set; }
        public string PLAVAVGA_QTTITCAP { get; set; }
        public string PLAVAVGA_VLTITCAP { get; set; }
        public string PLAVAVGA_VLCUSTCAP { get; set; }
        public string PLAVAVGA_IMPSEGCDG { get; set; }
        public string PLAVAVGA_VLCUSTCDG { get; set; }
        public string MOVIMVGA_DATA_MOVIMENTO { get; set; }
        public string SUBGVGAP_COD_SUBGRUPO { get; set; }
        public string SUBGVGAP_NUM_APOLICE { get; set; }
        public string PLAVAVGA_OPCAO_COBER { get; set; }
        public string PLAVAVGA_COD_PLANO { get; set; }
        public string PROPOVA_IDADE { get; set; }

        public static R3350_00_SELECT_PLANOS_DB_SELECT_1_Query1 Execute(R3350_00_SELECT_PLANOS_DB_SELECT_1_Query1 r3350_00_SELECT_PLANOS_DB_SELECT_1_Query1)
        {
            var ths = r3350_00_SELECT_PLANOS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3350_00_SELECT_PLANOS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3350_00_SELECT_PLANOS_DB_SELECT_1_Query1();
            var i = 0;
            dta.PLAVAVGA_IMPMORNATU = result[i++].Value?.ToString();
            dta.PLAVAVGA_IMPMORACID = result[i++].Value?.ToString();
            dta.PLAVAVGA_IMPINVPERM = result[i++].Value?.ToString();
            dta.PLAVAVGA_IMPAMDS = result[i++].Value?.ToString();
            dta.PLAVAVGA_IMPDH = result[i++].Value?.ToString();
            dta.PLAVAVGA_IMPDIT = result[i++].Value?.ToString();
            dta.PLAVAVGA_VLPREMIOTOT = result[i++].Value?.ToString();
            dta.PLAVAVGA_PRMVG = result[i++].Value?.ToString();
            dta.PLAVAVGA_PRMAP = result[i++].Value?.ToString();
            dta.PLAVAVGA_QTTITCAP = result[i++].Value?.ToString();
            dta.PLAVAVGA_VLTITCAP = result[i++].Value?.ToString();
            dta.PLAVAVGA_VLCUSTCAP = result[i++].Value?.ToString();
            dta.PLAVAVGA_IMPSEGCDG = result[i++].Value?.ToString();
            dta.PLAVAVGA_VLCUSTCDG = result[i++].Value?.ToString();
            return dta;
        }

    }
}