using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0072B
{
    public class R1160_00_SELECT_V1BILHETE_DB_SELECT_1_Query1 : QueryBasis<R1160_00_SELECT_V1BILHETE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            NUMBIL ,
            NUM_APOLICE,
            CODCLIEN ,
            AGECOBR ,
            RAMO ,
            OPC_COBERTURA,
            NUM_MATRICULA ,
            COD_AGENCIA ,
            OPERACAO_CONTA ,
            NUM_CONTA ,
            DIG_CONTA ,
            COD_AGENCIA_DEB ,
            OPERACAO_CONTA_DEB ,
            NUM_CONTA_DEB ,
            DIG_CONTA_DEB
            INTO :V0BILH-NUMBIL ,
            :V0BILH-NUMAPOL ,
            :V0BILH-CODCLIEN ,
            :V0BILH-AGECOBR ,
            :V0BILH-RAMO ,
            :V0BILH-OPCAO-COB ,
            :V0BILH-NRMATRVEN ,
            :V0BILH-AGECTAVEN ,
            :V0BILH-OPRCTAVEN ,
            :V0BILH-NUMCTAVEN ,
            :V0BILH-DIGCTAVEN ,
            :V0BILH-AGECTADEB ,
            :V0BILH-OPRCTADEB ,
            :V0BILH-NUMCTADEB ,
            :V0BILH-DIGCTADEB
            FROM SEGUROS.V0BILHETE
            WHERE NUMBIL = :V0BILH-NUMBIL
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											NUMBIL 
							,
											NUM_APOLICE
							,
											CODCLIEN 
							,
											AGECOBR 
							,
											RAMO 
							,
											OPC_COBERTURA
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
											COD_AGENCIA_DEB 
							,
											OPERACAO_CONTA_DEB 
							,
											NUM_CONTA_DEB 
							,
											DIG_CONTA_DEB
											FROM SEGUROS.V0BILHETE
											WHERE NUMBIL = '{this.V0BILH_NUMBIL}'";

            return query;
        }
        public string V0BILH_NUMBIL { get; set; }
        public string V0BILH_NUMAPOL { get; set; }
        public string V0BILH_CODCLIEN { get; set; }
        public string V0BILH_AGECOBR { get; set; }
        public string V0BILH_RAMO { get; set; }
        public string V0BILH_OPCAO_COB { get; set; }
        public string V0BILH_NRMATRVEN { get; set; }
        public string V0BILH_AGECTAVEN { get; set; }
        public string V0BILH_OPRCTAVEN { get; set; }
        public string V0BILH_NUMCTAVEN { get; set; }
        public string V0BILH_DIGCTAVEN { get; set; }
        public string V0BILH_AGECTADEB { get; set; }
        public string V0BILH_OPRCTADEB { get; set; }
        public string V0BILH_NUMCTADEB { get; set; }
        public string V0BILH_DIGCTADEB { get; set; }

        public static R1160_00_SELECT_V1BILHETE_DB_SELECT_1_Query1 Execute(R1160_00_SELECT_V1BILHETE_DB_SELECT_1_Query1 r1160_00_SELECT_V1BILHETE_DB_SELECT_1_Query1)
        {
            var ths = r1160_00_SELECT_V1BILHETE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1160_00_SELECT_V1BILHETE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1160_00_SELECT_V1BILHETE_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0BILH_NUMBIL = result[i++].Value?.ToString();
            dta.V0BILH_NUMAPOL = result[i++].Value?.ToString();
            dta.V0BILH_CODCLIEN = result[i++].Value?.ToString();
            dta.V0BILH_AGECOBR = result[i++].Value?.ToString();
            dta.V0BILH_RAMO = result[i++].Value?.ToString();
            dta.V0BILH_OPCAO_COB = result[i++].Value?.ToString();
            dta.V0BILH_NRMATRVEN = result[i++].Value?.ToString();
            dta.V0BILH_AGECTAVEN = result[i++].Value?.ToString();
            dta.V0BILH_OPRCTAVEN = result[i++].Value?.ToString();
            dta.V0BILH_NUMCTAVEN = result[i++].Value?.ToString();
            dta.V0BILH_DIGCTAVEN = result[i++].Value?.ToString();
            dta.V0BILH_AGECTADEB = result[i++].Value?.ToString();
            dta.V0BILH_OPRCTADEB = result[i++].Value?.ToString();
            dta.V0BILH_NUMCTADEB = result[i++].Value?.ToString();
            dta.V0BILH_DIGCTADEB = result[i++].Value?.ToString();
            return dta;
        }

    }
}