using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0009B
{
    public class R7600_00_SELECT_V0BILHETE_DB_SELECT_1_Query1 : QueryBasis<R7600_00_SELECT_V0BILHETE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_APOLICE ,
            FONTE ,
            AGECOBR ,
            NUM_MATRICULA ,
            COD_AGENCIA ,
            OPERACAO_CONTA ,
            NUM_CONTA ,
            DIG_CONTA ,
            CODCLIEN ,
            PROFISSAO ,
            IDE_SEXO ,
            ESTADO_CIVIL ,
            OCORR_ENDERECO ,
            COD_AGENCIA_DEB ,
            OPERACAO_CONTA_DEB ,
            NUM_CONTA_DEB ,
            DIG_CONTA_DEB ,
            OPC_COBERTURA ,
            DTQITBCO ,
            VLRCAP ,
            RAMO ,
            DATA_VENDA ,
            NUM_APOL_ANTERIOR ,
            TIP_CANCELAMENTO ,
            SIT_SINISTRO ,
            BI_FAIXA_RENDA_IND ,
            BI_FAIXA_RENDA_FAM ,
            COD_PRODUTO
            INTO :V0BILH-NUMAPOL ,
            :V0BILH-FONTE ,
            :V0BILH-AGECOBR ,
            :V0BILH-MATRICULA ,
            :V0BILH-AGECONTA ,
            :V0BILH-OPECONTA ,
            :V0BILH-NUMCONTA ,
            :V0BILH-DIGCONTA ,
            :V0BILH-CODCLIEN ,
            :V0BILH-PROFISSAO ,
            :V0BILH-SEXO ,
            :V0BILH-ESTCIV ,
            :V0BILH-OCOREND ,
            :V0BILH-AGECONDEB ,
            :V0BILH-OPECONDEB ,
            :V0BILH-NUMCONDEB ,
            :V0BILH-DIGCONDEB ,
            :V0BILH-OPCOBER ,
            :V0BILH-DTQITBCO ,
            :V0BILH-VLRCAP ,
            :V0BILH-RAMO ,
            :V0BILH-DTVENDA ,
            :V0BILH-NUMAPOLANT ,
            :V0BILH-TIPCANCEL ,
            :V0BILH-TIPSINIST ,
            :V0BILH-FX-RENDA-IND ,
            :V0BILH-FX-RENDA-FAM ,
            :V0BILH-COD-PRODUTO
            FROM SEGUROS.V0BILHETE
            WHERE NUMBIL = :V0BILH-NUMBIL
            AND SITUACAO = '8'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_APOLICE 
							,
											FONTE 
							,
											AGECOBR 
							,
											NUM_MATRICULA 
							,
											COD_AGENCIA 
							,
											OPERACAO_CONTA 
							,
											NUM_CONTA 
							,
											DIG_CONTA 
							,
											CODCLIEN 
							,
											PROFISSAO 
							,
											IDE_SEXO 
							,
											ESTADO_CIVIL 
							,
											OCORR_ENDERECO 
							,
											COD_AGENCIA_DEB 
							,
											OPERACAO_CONTA_DEB 
							,
											NUM_CONTA_DEB 
							,
											DIG_CONTA_DEB 
							,
											OPC_COBERTURA 
							,
											DTQITBCO 
							,
											VLRCAP 
							,
											RAMO 
							,
											DATA_VENDA 
							,
											NUM_APOL_ANTERIOR 
							,
											TIP_CANCELAMENTO 
							,
											SIT_SINISTRO 
							,
											BI_FAIXA_RENDA_IND 
							,
											BI_FAIXA_RENDA_FAM 
							,
											COD_PRODUTO
											FROM SEGUROS.V0BILHETE
											WHERE NUMBIL = '{this.V0BILH_NUMBIL}'
											AND SITUACAO = '8'";

            return query;
        }
        public string V0BILH_NUMAPOL { get; set; }
        public string V0BILH_FONTE { get; set; }
        public string V0BILH_AGECOBR { get; set; }
        public string V0BILH_MATRICULA { get; set; }
        public string V0BILH_AGECONTA { get; set; }
        public string V0BILH_OPECONTA { get; set; }
        public string V0BILH_NUMCONTA { get; set; }
        public string V0BILH_DIGCONTA { get; set; }
        public string V0BILH_CODCLIEN { get; set; }
        public string V0BILH_PROFISSAO { get; set; }
        public string V0BILH_SEXO { get; set; }
        public string V0BILH_ESTCIV { get; set; }
        public string V0BILH_OCOREND { get; set; }
        public string V0BILH_AGECONDEB { get; set; }
        public string V0BILH_OPECONDEB { get; set; }
        public string V0BILH_NUMCONDEB { get; set; }
        public string V0BILH_DIGCONDEB { get; set; }
        public string V0BILH_OPCOBER { get; set; }
        public string V0BILH_DTQITBCO { get; set; }
        public string V0BILH_VLRCAP { get; set; }
        public string V0BILH_RAMO { get; set; }
        public string V0BILH_DTVENDA { get; set; }
        public string V0BILH_NUMAPOLANT { get; set; }
        public string V0BILH_TIPCANCEL { get; set; }
        public string V0BILH_TIPSINIST { get; set; }
        public string V0BILH_FX_RENDA_IND { get; set; }
        public string V0BILH_FX_RENDA_FAM { get; set; }
        public string V0BILH_COD_PRODUTO { get; set; }
        public string V0BILH_NUMBIL { get; set; }

        public static R7600_00_SELECT_V0BILHETE_DB_SELECT_1_Query1 Execute(R7600_00_SELECT_V0BILHETE_DB_SELECT_1_Query1 r7600_00_SELECT_V0BILHETE_DB_SELECT_1_Query1)
        {
            var ths = r7600_00_SELECT_V0BILHETE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R7600_00_SELECT_V0BILHETE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R7600_00_SELECT_V0BILHETE_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0BILH_NUMAPOL = result[i++].Value?.ToString();
            dta.V0BILH_FONTE = result[i++].Value?.ToString();
            dta.V0BILH_AGECOBR = result[i++].Value?.ToString();
            dta.V0BILH_MATRICULA = result[i++].Value?.ToString();
            dta.V0BILH_AGECONTA = result[i++].Value?.ToString();
            dta.V0BILH_OPECONTA = result[i++].Value?.ToString();
            dta.V0BILH_NUMCONTA = result[i++].Value?.ToString();
            dta.V0BILH_DIGCONTA = result[i++].Value?.ToString();
            dta.V0BILH_CODCLIEN = result[i++].Value?.ToString();
            dta.V0BILH_PROFISSAO = result[i++].Value?.ToString();
            dta.V0BILH_SEXO = result[i++].Value?.ToString();
            dta.V0BILH_ESTCIV = result[i++].Value?.ToString();
            dta.V0BILH_OCOREND = result[i++].Value?.ToString();
            dta.V0BILH_AGECONDEB = result[i++].Value?.ToString();
            dta.V0BILH_OPECONDEB = result[i++].Value?.ToString();
            dta.V0BILH_NUMCONDEB = result[i++].Value?.ToString();
            dta.V0BILH_DIGCONDEB = result[i++].Value?.ToString();
            dta.V0BILH_OPCOBER = result[i++].Value?.ToString();
            dta.V0BILH_DTQITBCO = result[i++].Value?.ToString();
            dta.V0BILH_VLRCAP = result[i++].Value?.ToString();
            dta.V0BILH_RAMO = result[i++].Value?.ToString();
            dta.V0BILH_DTVENDA = result[i++].Value?.ToString();
            dta.V0BILH_NUMAPOLANT = result[i++].Value?.ToString();
            dta.V0BILH_TIPCANCEL = result[i++].Value?.ToString();
            dta.V0BILH_TIPSINIST = result[i++].Value?.ToString();
            dta.V0BILH_FX_RENDA_IND = result[i++].Value?.ToString();
            dta.V0BILH_FX_RENDA_FAM = result[i++].Value?.ToString();
            dta.V0BILH_COD_PRODUTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}