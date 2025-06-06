using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA3139B
{
    public class R1350_00_LER_V0HISTOPARC_DB_SELECT_1_Query1 : QueryBasis<R1350_00_LER_V0HISTOPARC_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_APOLICE,
            NRENDOS,
            NRPARCEL,
            DACPARC,
            DTMOVTO,
            OPERACAO,
            OCORHIST,
            PRM_TARIFARIO,
            VAL_DESCONTO,
            VLPRMLIQ,
            VLADIFRA,
            VLCUSEMI,
            VLIOCC,
            VLPRMTOT,
            VLPREMIO,
            DTVENCTO,
            BCOCOBR,
            AGECOBR,
            NRAVISO,
            NRENDOCA,
            SITCONTB,
            COD_USUARIO,
            RNUDOC,
            DTQITBCO,
            COD_EMPRESA
            INTO :V0HISP-NUM-APOL,
            :V0HISP-NRENDOS,
            :V0HISP-NRPARCEL,
            :V0HISP-DACPARC,
            :V0HISP-DTMOVTO,
            :V0HISP-OPERACAO,
            :V0HISP-OCORHIST,
            :V0HISP-PRM-TARIFA,
            :V0HISP-VAL-DESCON,
            :V0HISP-VLPRMLIQ,
            :V0HISP-VLADIFRA,
            :V0HISP-VLCUSEMI,
            :V0HISP-VLIOCC,
            :V0HISP-VLPRMTOT,
            :V0HISP-VLPREMIO,
            :V0HISP-DTVENCTO,
            :V0HISP-BCOCOBR,
            :V0HISP-AGECOBR,
            :V0HISP-NRAVISO,
            :V0HISP-NRENDOCA,
            :V0HISP-SITCONTB,
            :V0HISP-COD-USUAR,
            :V0HISP-RNUDOC,
            :V0HISP-DTQITBCO:VIND-DTQITBCO,
            :V0HISP-COD-EMPRESA
            FROM SEGUROS.V0HISTOPARC
            WHERE NUM_APOLICE = :V0ENDO-NUM-APOLICE
            AND NRENDOS = :V0ENDO-NRENDOS
            AND OPERACAO >= 100
            AND OPERACAO <= 199
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_APOLICE
							,
											NRENDOS
							,
											NRPARCEL
							,
											DACPARC
							,
											DTMOVTO
							,
											OPERACAO
							,
											OCORHIST
							,
											PRM_TARIFARIO
							,
											VAL_DESCONTO
							,
											VLPRMLIQ
							,
											VLADIFRA
							,
											VLCUSEMI
							,
											VLIOCC
							,
											VLPRMTOT
							,
											VLPREMIO
							,
											DTVENCTO
							,
											BCOCOBR
							,
											AGECOBR
							,
											NRAVISO
							,
											NRENDOCA
							,
											SITCONTB
							,
											COD_USUARIO
							,
											RNUDOC
							,
											DTQITBCO
							,
											COD_EMPRESA
											FROM SEGUROS.V0HISTOPARC
											WHERE NUM_APOLICE = '{this.V0ENDO_NUM_APOLICE}'
											AND NRENDOS = '{this.V0ENDO_NRENDOS}'
											AND OPERACAO >= 100
											AND OPERACAO <= 199";

            return query;
        }
        public string V0HISP_NUM_APOL { get; set; }
        public string V0HISP_NRENDOS { get; set; }
        public string V0HISP_NRPARCEL { get; set; }
        public string V0HISP_DACPARC { get; set; }
        public string V0HISP_DTMOVTO { get; set; }
        public string V0HISP_OPERACAO { get; set; }
        public string V0HISP_OCORHIST { get; set; }
        public string V0HISP_PRM_TARIFA { get; set; }
        public string V0HISP_VAL_DESCON { get; set; }
        public string V0HISP_VLPRMLIQ { get; set; }
        public string V0HISP_VLADIFRA { get; set; }
        public string V0HISP_VLCUSEMI { get; set; }
        public string V0HISP_VLIOCC { get; set; }
        public string V0HISP_VLPRMTOT { get; set; }
        public string V0HISP_VLPREMIO { get; set; }
        public string V0HISP_DTVENCTO { get; set; }
        public string V0HISP_BCOCOBR { get; set; }
        public string V0HISP_AGECOBR { get; set; }
        public string V0HISP_NRAVISO { get; set; }
        public string V0HISP_NRENDOCA { get; set; }
        public string V0HISP_SITCONTB { get; set; }
        public string V0HISP_COD_USUAR { get; set; }
        public string V0HISP_RNUDOC { get; set; }
        public string V0HISP_DTQITBCO { get; set; }
        public string VIND_DTQITBCO { get; set; }
        public string V0HISP_COD_EMPRESA { get; set; }
        public string V0ENDO_NUM_APOLICE { get; set; }
        public string V0ENDO_NRENDOS { get; set; }

        public static R1350_00_LER_V0HISTOPARC_DB_SELECT_1_Query1 Execute(R1350_00_LER_V0HISTOPARC_DB_SELECT_1_Query1 r1350_00_LER_V0HISTOPARC_DB_SELECT_1_Query1)
        {
            var ths = r1350_00_LER_V0HISTOPARC_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1350_00_LER_V0HISTOPARC_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1350_00_LER_V0HISTOPARC_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0HISP_NUM_APOL = result[i++].Value?.ToString();
            dta.V0HISP_NRENDOS = result[i++].Value?.ToString();
            dta.V0HISP_NRPARCEL = result[i++].Value?.ToString();
            dta.V0HISP_DACPARC = result[i++].Value?.ToString();
            dta.V0HISP_DTMOVTO = result[i++].Value?.ToString();
            dta.V0HISP_OPERACAO = result[i++].Value?.ToString();
            dta.V0HISP_OCORHIST = result[i++].Value?.ToString();
            dta.V0HISP_PRM_TARIFA = result[i++].Value?.ToString();
            dta.V0HISP_VAL_DESCON = result[i++].Value?.ToString();
            dta.V0HISP_VLPRMLIQ = result[i++].Value?.ToString();
            dta.V0HISP_VLADIFRA = result[i++].Value?.ToString();
            dta.V0HISP_VLCUSEMI = result[i++].Value?.ToString();
            dta.V0HISP_VLIOCC = result[i++].Value?.ToString();
            dta.V0HISP_VLPRMTOT = result[i++].Value?.ToString();
            dta.V0HISP_VLPREMIO = result[i++].Value?.ToString();
            dta.V0HISP_DTVENCTO = result[i++].Value?.ToString();
            dta.V0HISP_BCOCOBR = result[i++].Value?.ToString();
            dta.V0HISP_AGECOBR = result[i++].Value?.ToString();
            dta.V0HISP_NRAVISO = result[i++].Value?.ToString();
            dta.V0HISP_NRENDOCA = result[i++].Value?.ToString();
            dta.V0HISP_SITCONTB = result[i++].Value?.ToString();
            dta.V0HISP_COD_USUAR = result[i++].Value?.ToString();
            dta.V0HISP_RNUDOC = result[i++].Value?.ToString();
            dta.V0HISP_DTQITBCO = result[i++].Value?.ToString();
            dta.VIND_DTQITBCO = string.IsNullOrWhiteSpace(dta.V0HISP_DTQITBCO) ? "-1" : "0";
            dta.V0HISP_COD_EMPRESA = result[i++].Value?.ToString();
            return dta;
        }

    }
}