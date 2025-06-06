using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0123B
{
    public class R1401_00_SELECT_PLAVAVGA_DB_SELECT_1_Query1 : QueryBasis<R1401_00_SELECT_PLAVAVGA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT IMPMORNATU ,
            IMPMORACID ,
            VLPREMIOTOT ,
            PRMVG ,
            PRMAP ,
            FAIXA ,
            QTTITCAP ,
            VLTITCAP ,
            VLCUSTCAP ,
            PCT_FAIXA_ETARIA
            INTO
            :PLAVAVGA-IMPMORNATU ,
            :PLAVAVGA-IMPMORACID ,
            :PLAVAVGA-VLPREMIOTOT ,
            :PLAVAVGA-PRMVG ,
            :PLAVAVGA-PRMAP ,
            :PLAVAVGA-FAIXA ,
            :PLAVAVGA-QTTITCAP ,
            :PLAVAVGA-VLTITCAP ,
            :PLAVAVGA-VLCUSTCAP ,
            :PLAVAVGA-PCT-FAIXA-ETARIA
            FROM SEGUROS.PLANOS_VA_VGAP
            WHERE NUM_APOLICE = :PROPOVA-NUM-APOLICE
            AND CODSUBES = :SUBGVGAP-COD-SUBGRUPO
            AND OPCAO_COBER = :HISCOBPR-OPCAO-COBERTURA
            AND IDADE_INICIAL <= :PROPOVA-IDADE
            AND IDADE_FINAL >= :PROPOVA-IDADE
            AND PERIPGTO = :PRODUVG-PERI-PAGAMENTO
            AND DTTERVIG = '9999-12-31'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT IMPMORNATU 
							,
											IMPMORACID 
							,
											VLPREMIOTOT 
							,
											PRMVG 
							,
											PRMAP 
							,
											FAIXA 
							,
											QTTITCAP 
							,
											VLTITCAP 
							,
											VLCUSTCAP 
							,
											PCT_FAIXA_ETARIA
											FROM SEGUROS.PLANOS_VA_VGAP
											WHERE NUM_APOLICE = '{this.PROPOVA_NUM_APOLICE}'
											AND CODSUBES = '{this.SUBGVGAP_COD_SUBGRUPO}'
											AND OPCAO_COBER = '{this.HISCOBPR_OPCAO_COBERTURA}'
											AND IDADE_INICIAL <= '{this.PROPOVA_IDADE}'
											AND IDADE_FINAL >= '{this.PROPOVA_IDADE}'
											AND PERIPGTO = '{this.PRODUVG_PERI_PAGAMENTO}'
											AND DTTERVIG = '9999-12-31'
											WITH UR";

            return query;
        }
        public string PLAVAVGA_IMPMORNATU { get; set; }
        public string PLAVAVGA_IMPMORACID { get; set; }
        public string PLAVAVGA_VLPREMIOTOT { get; set; }
        public string PLAVAVGA_PRMVG { get; set; }
        public string PLAVAVGA_PRMAP { get; set; }
        public string PLAVAVGA_FAIXA { get; set; }
        public string PLAVAVGA_QTTITCAP { get; set; }
        public string PLAVAVGA_VLTITCAP { get; set; }
        public string PLAVAVGA_VLCUSTCAP { get; set; }
        public string PLAVAVGA_PCT_FAIXA_ETARIA { get; set; }
        public string HISCOBPR_OPCAO_COBERTURA { get; set; }
        public string PRODUVG_PERI_PAGAMENTO { get; set; }
        public string SUBGVGAP_COD_SUBGRUPO { get; set; }
        public string PROPOVA_NUM_APOLICE { get; set; }
        public string PROPOVA_IDADE { get; set; }

        public static R1401_00_SELECT_PLAVAVGA_DB_SELECT_1_Query1 Execute(R1401_00_SELECT_PLAVAVGA_DB_SELECT_1_Query1 r1401_00_SELECT_PLAVAVGA_DB_SELECT_1_Query1)
        {
            var ths = r1401_00_SELECT_PLAVAVGA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1401_00_SELECT_PLAVAVGA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1401_00_SELECT_PLAVAVGA_DB_SELECT_1_Query1();
            var i = 0;
            dta.PLAVAVGA_IMPMORNATU = result[i++].Value?.ToString();
            dta.PLAVAVGA_IMPMORACID = result[i++].Value?.ToString();
            dta.PLAVAVGA_VLPREMIOTOT = result[i++].Value?.ToString();
            dta.PLAVAVGA_PRMVG = result[i++].Value?.ToString();
            dta.PLAVAVGA_PRMAP = result[i++].Value?.ToString();
            dta.PLAVAVGA_FAIXA = result[i++].Value?.ToString();
            dta.PLAVAVGA_QTTITCAP = result[i++].Value?.ToString();
            dta.PLAVAVGA_VLTITCAP = result[i++].Value?.ToString();
            dta.PLAVAVGA_VLCUSTCAP = result[i++].Value?.ToString();
            dta.PLAVAVGA_PCT_FAIXA_ETARIA = result[i++].Value?.ToString();
            return dta;
        }

    }
}