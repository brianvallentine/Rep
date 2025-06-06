using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0202B
{
    public class R1100_00_LER_HISTOPARC_DB_SELECT_1_Query1 : QueryBasis<R1100_00_LER_HISTOPARC_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_APOLICE , NRENDOS ,
            NRPARCEL , DACPARC ,
            DTMOVTO , OPERACAO ,
            OCORHIST , PRM_TARIFARIO,
            VAL_DESCONTO , VLPRMLIQ ,
            VLADIFRA , VLCUSEMI ,
            VLIOCC , VLPRMTOT ,
            VLPREMIO , DTVENCTO ,
            BCOCOBR , AGECOBR ,
            NRAVISO , NRENDOCA ,
            SITCONTB , COD_USUARIO ,
            RNUDOC ,
            VALUE(DTQITBCO, DATE( '9999-12-31' )),
            VALUE(COD_EMPRESA, 0)
            INTO :V1HIST-NUM-APOL , :V1HIST-NRENDOS ,
            :V1HIST-NRPARCEL , :V1HIST-DACPARC ,
            :V1HIST-DTMOVTO , :V1HIST-OPERACAO ,
            :V1HIST-OCORHIST , :V1HIST-PRM-TARIF ,
            :V1HIST-DESCONTO , :V1HIST-VLPRMLIQ ,
            :V1HIST-VLADIFRA , :V1HIST-VLCUSEMI ,
            :V1HIST-VLIOCC , :V1HIST-VLPRMTOT ,
            :V1HIST-VLPREMIO , :V1HIST-DTVENCTO ,
            :V1HIST-BCOCOBR , :V1HIST-AGECOBR ,
            :V1HIST-NRAVISO , :V1HIST-NRENDOCA ,
            :V1HIST-SITCONTB , :V1HIST-USUARIO ,
            :V1HIST-RNUDOC , :V1HIST-DTQITBCO ,
            :V1HIST-EMPRESA
            FROM SEGUROS.V1HISTOPARC
            WHERE NUM_APOLICE = :V1EDIA-NUM-APOL
            AND NRENDOS = :V1EDIA-NRENDOS
            AND NRPARCEL = 0
            AND OPERACAO = 101
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_APOLICE 
							, NRENDOS 
							,
											NRPARCEL 
							, DACPARC 
							,
											DTMOVTO 
							, OPERACAO 
							,
											OCORHIST 
							, PRM_TARIFARIO
							,
											VAL_DESCONTO 
							, VLPRMLIQ 
							,
											VLADIFRA 
							, VLCUSEMI 
							,
											VLIOCC 
							, VLPRMTOT 
							,
											VLPREMIO 
							, DTVENCTO 
							,
											BCOCOBR 
							, AGECOBR 
							,
											NRAVISO 
							, NRENDOCA 
							,
											SITCONTB 
							, COD_USUARIO 
							,
											RNUDOC 
							,
											VALUE(DTQITBCO
							, DATE( '9999-12-31' ))
							,
											VALUE(COD_EMPRESA
							, 0)
											FROM SEGUROS.V1HISTOPARC
											WHERE NUM_APOLICE = '{this.V1EDIA_NUM_APOL}'
											AND NRENDOS = '{this.V1EDIA_NRENDOS}'
											AND NRPARCEL = 0
											AND OPERACAO = 101";

            return query;
        }
        public string V1HIST_NUM_APOL { get; set; }
        public string V1HIST_NRENDOS { get; set; }
        public string V1HIST_NRPARCEL { get; set; }
        public string V1HIST_DACPARC { get; set; }
        public string V1HIST_DTMOVTO { get; set; }
        public string V1HIST_OPERACAO { get; set; }
        public string V1HIST_OCORHIST { get; set; }
        public string V1HIST_PRM_TARIF { get; set; }
        public string V1HIST_DESCONTO { get; set; }
        public string V1HIST_VLPRMLIQ { get; set; }
        public string V1HIST_VLADIFRA { get; set; }
        public string V1HIST_VLCUSEMI { get; set; }
        public string V1HIST_VLIOCC { get; set; }
        public string V1HIST_VLPRMTOT { get; set; }
        public string V1HIST_VLPREMIO { get; set; }
        public string V1HIST_DTVENCTO { get; set; }
        public string V1HIST_BCOCOBR { get; set; }
        public string V1HIST_AGECOBR { get; set; }
        public string V1HIST_NRAVISO { get; set; }
        public string V1HIST_NRENDOCA { get; set; }
        public string V1HIST_SITCONTB { get; set; }
        public string V1HIST_USUARIO { get; set; }
        public string V1HIST_RNUDOC { get; set; }
        public string V1HIST_DTQITBCO { get; set; }
        public string V1HIST_EMPRESA { get; set; }
        public string V1EDIA_NUM_APOL { get; set; }
        public string V1EDIA_NRENDOS { get; set; }

        public static R1100_00_LER_HISTOPARC_DB_SELECT_1_Query1 Execute(R1100_00_LER_HISTOPARC_DB_SELECT_1_Query1 r1100_00_LER_HISTOPARC_DB_SELECT_1_Query1)
        {
            var ths = r1100_00_LER_HISTOPARC_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1100_00_LER_HISTOPARC_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1100_00_LER_HISTOPARC_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1HIST_NUM_APOL = result[i++].Value?.ToString();
            dta.V1HIST_NRENDOS = result[i++].Value?.ToString();
            dta.V1HIST_NRPARCEL = result[i++].Value?.ToString();
            dta.V1HIST_DACPARC = result[i++].Value?.ToString();
            dta.V1HIST_DTMOVTO = result[i++].Value?.ToString();
            dta.V1HIST_OPERACAO = result[i++].Value?.ToString();
            dta.V1HIST_OCORHIST = result[i++].Value?.ToString();
            dta.V1HIST_PRM_TARIF = result[i++].Value?.ToString();
            dta.V1HIST_DESCONTO = result[i++].Value?.ToString();
            dta.V1HIST_VLPRMLIQ = result[i++].Value?.ToString();
            dta.V1HIST_VLADIFRA = result[i++].Value?.ToString();
            dta.V1HIST_VLCUSEMI = result[i++].Value?.ToString();
            dta.V1HIST_VLIOCC = result[i++].Value?.ToString();
            dta.V1HIST_VLPRMTOT = result[i++].Value?.ToString();
            dta.V1HIST_VLPREMIO = result[i++].Value?.ToString();
            dta.V1HIST_DTVENCTO = result[i++].Value?.ToString();
            dta.V1HIST_BCOCOBR = result[i++].Value?.ToString();
            dta.V1HIST_AGECOBR = result[i++].Value?.ToString();
            dta.V1HIST_NRAVISO = result[i++].Value?.ToString();
            dta.V1HIST_NRENDOCA = result[i++].Value?.ToString();
            dta.V1HIST_SITCONTB = result[i++].Value?.ToString();
            dta.V1HIST_USUARIO = result[i++].Value?.ToString();
            dta.V1HIST_RNUDOC = result[i++].Value?.ToString();
            dta.V1HIST_DTQITBCO = result[i++].Value?.ToString();
            dta.V1HIST_EMPRESA = result[i++].Value?.ToString();
            return dta;
        }

    }
}