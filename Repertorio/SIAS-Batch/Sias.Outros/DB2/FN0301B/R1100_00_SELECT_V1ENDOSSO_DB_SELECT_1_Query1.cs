using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.FN0301B
{
    public class R1100_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1 : QueryBasis<R1100_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_APOLICE,
            NRENDOS,
            CODSUBES,
            FONTE ,
            NRPROPOS,
            NUMBIL,
            NRRCAP,
            RAMO ,
            CODPRODU,
            NUM_APOL_ANTERIOR,
            DTEMIS ,
            DTINIVIG ,
            DTTERVIG ,
            CODCLIEN,
            QTPARCEL,
            OCORR_ENDERECO ,
            COD_MOEDA_IMP,
            COD_MOEDA_PRM,
            TIPO_ENDOSSO,
            SITUACAO,
            AGERCAP,
            AGECOBR
            INTO :V1ENDO-NUMAPOL,
            :V1ENDO-NRENDOS,
            :V1ENDO-CODSUBES,
            :V1ENDO-FONTE ,
            :V1ENDO-NRPROPOS,
            :V1ENDO-NUMBIL,
            :V1ENDO-NRRCAP,
            :V1ENDO-RAMO ,
            :V1ENDO-CODPRODU:VIND-CODPRODU,
            :V1ENDO-APOLANT,
            :V1ENDO-DTEMIS,
            :V1ENDO-DTINIVIG,
            :V1ENDO-DTTERVIG,
            :V1ENDO-CODCLIEN,
            :V1ENDO-QTPARCEL,
            :V1ENDO-OCORR-END ,
            :V1ENDO-MOEDA-IMP,
            :V1ENDO-MOEDA-PRM,
            :V1ENDO-TIPO-ENDO,
            :V1ENDO-SITUACAO,
            :V1ENDO-AGERCAP,
            :V1ENDO-AGECOBR
            FROM SEGUROS.V1ENDOSSO
            WHERE NUM_APOLICE = :V1HISP-NUMAPOL
            AND NRENDOS = :V1HISP-NRENDOS
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_APOLICE
							,
											NRENDOS
							,
											CODSUBES
							,
											FONTE 
							,
											NRPROPOS
							,
											NUMBIL
							,
											NRRCAP
							,
											RAMO 
							,
											CODPRODU
							,
											NUM_APOL_ANTERIOR
							,
											DTEMIS 
							,
											DTINIVIG 
							,
											DTTERVIG 
							,
											CODCLIEN
							,
											QTPARCEL
							,
											OCORR_ENDERECO 
							,
											COD_MOEDA_IMP
							,
											COD_MOEDA_PRM
							,
											TIPO_ENDOSSO
							,
											SITUACAO
							,
											AGERCAP
							,
											AGECOBR
											FROM SEGUROS.V1ENDOSSO
											WHERE NUM_APOLICE = '{this.V1HISP_NUMAPOL}'
											AND NRENDOS = '{this.V1HISP_NRENDOS}'
											WITH UR";

            return query;
        }
        public string V1ENDO_NUMAPOL { get; set; }
        public string V1ENDO_NRENDOS { get; set; }
        public string V1ENDO_CODSUBES { get; set; }
        public string V1ENDO_FONTE { get; set; }
        public string V1ENDO_NRPROPOS { get; set; }
        public string V1ENDO_NUMBIL { get; set; }
        public string V1ENDO_NRRCAP { get; set; }
        public string V1ENDO_RAMO { get; set; }
        public string V1ENDO_CODPRODU { get; set; }
        public string VIND_CODPRODU { get; set; }
        public string V1ENDO_APOLANT { get; set; }
        public string V1ENDO_DTEMIS { get; set; }
        public string V1ENDO_DTINIVIG { get; set; }
        public string V1ENDO_DTTERVIG { get; set; }
        public string V1ENDO_CODCLIEN { get; set; }
        public string V1ENDO_QTPARCEL { get; set; }
        public string V1ENDO_OCORR_END { get; set; }
        public string V1ENDO_MOEDA_IMP { get; set; }
        public string V1ENDO_MOEDA_PRM { get; set; }
        public string V1ENDO_TIPO_ENDO { get; set; }
        public string V1ENDO_SITUACAO { get; set; }
        public string V1ENDO_AGERCAP { get; set; }
        public string V1ENDO_AGECOBR { get; set; }
        public string V1HISP_NUMAPOL { get; set; }
        public string V1HISP_NRENDOS { get; set; }

        public static R1100_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1 Execute(R1100_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1 r1100_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1)
        {
            var ths = r1100_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1100_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1100_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1ENDO_NUMAPOL = result[i++].Value?.ToString();
            dta.V1ENDO_NRENDOS = result[i++].Value?.ToString();
            dta.V1ENDO_CODSUBES = result[i++].Value?.ToString();
            dta.V1ENDO_FONTE = result[i++].Value?.ToString();
            dta.V1ENDO_NRPROPOS = result[i++].Value?.ToString();
            dta.V1ENDO_NUMBIL = result[i++].Value?.ToString();
            dta.V1ENDO_NRRCAP = result[i++].Value?.ToString();
            dta.V1ENDO_RAMO = result[i++].Value?.ToString();
            dta.V1ENDO_CODPRODU = result[i++].Value?.ToString();
            dta.VIND_CODPRODU = string.IsNullOrWhiteSpace(dta.V1ENDO_CODPRODU) ? "-1" : "0";
            dta.V1ENDO_APOLANT = result[i++].Value?.ToString();
            dta.V1ENDO_DTEMIS = result[i++].Value?.ToString();
            dta.V1ENDO_DTINIVIG = result[i++].Value?.ToString();
            dta.V1ENDO_DTTERVIG = result[i++].Value?.ToString();
            dta.V1ENDO_CODCLIEN = result[i++].Value?.ToString();
            dta.V1ENDO_QTPARCEL = result[i++].Value?.ToString();
            dta.V1ENDO_OCORR_END = result[i++].Value?.ToString();
            dta.V1ENDO_MOEDA_IMP = result[i++].Value?.ToString();
            dta.V1ENDO_MOEDA_PRM = result[i++].Value?.ToString();
            dta.V1ENDO_TIPO_ENDO = result[i++].Value?.ToString();
            dta.V1ENDO_SITUACAO = result[i++].Value?.ToString();
            dta.V1ENDO_AGERCAP = result[i++].Value?.ToString();
            dta.V1ENDO_AGECOBR = result[i++].Value?.ToString();
            return dta;
        }

    }
}