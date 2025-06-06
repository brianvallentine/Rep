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
    public class R1311_00_DEMAIS_PARCELAS_DB_SELECT_1_Query1 : QueryBasis<R1311_00_DEMAIS_PARCELAS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.NUM_APOLICE ,
            A.NRENDOS ,
            A.NRPARCEL ,
            A.NRTIT ,
            A.OTNPRLIQ ,
            A.OCORHIST ,
            A.SITUACAO ,
            B.DTVENCTO
            INTO :V1PARC-NUMAPOL ,
            :V1PARC-NRENDOS ,
            :V1PARC-NRPARCEL ,
            :V1PARC-NRTIT ,
            :V1PARC-VLPRMLIQ ,
            :V1PARC-QTDOCORR ,
            :V1PARC-SITUACAO ,
            :V1HISP-DTVENCTO
            FROM SEGUROS.V1PARCELA A,
            SEGUROS.V1HISTOPARC B
            WHERE A.NUM_APOLICE = :V1ENDO-NUMAPOL
            AND A.NRENDOS = :V1ENDO-NRENDOS
            AND A.NRPARCEL = :AC-PARC
            AND A.NUM_APOLICE = B.NUM_APOLICE
            AND A.NRENDOS = B.NRENDOS
            AND A.NRPARCEL = B.NRPARCEL
            AND B.OPERACAO BETWEEN 100 AND 199
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT A.NUM_APOLICE 
							,
											A.NRENDOS 
							,
											A.NRPARCEL 
							,
											A.NRTIT 
							,
											A.OTNPRLIQ 
							,
											A.OCORHIST 
							,
											A.SITUACAO 
							,
											B.DTVENCTO
											FROM SEGUROS.V1PARCELA A
							,
											SEGUROS.V1HISTOPARC B
											WHERE A.NUM_APOLICE = '{this.V1ENDO_NUMAPOL}'
											AND A.NRENDOS = '{this.V1ENDO_NRENDOS}'
											AND A.NRPARCEL = '{this.AC_PARC}'
											AND A.NUM_APOLICE = B.NUM_APOLICE
											AND A.NRENDOS = B.NRENDOS
											AND A.NRPARCEL = B.NRPARCEL
											AND B.OPERACAO BETWEEN 100 AND 199
											WITH UR";

            return query;
        }
        public string V1PARC_NUMAPOL { get; set; }
        public string V1PARC_NRENDOS { get; set; }
        public string V1PARC_NRPARCEL { get; set; }
        public string V1PARC_NRTIT { get; set; }
        public string V1PARC_VLPRMLIQ { get; set; }
        public string V1PARC_QTDOCORR { get; set; }
        public string V1PARC_SITUACAO { get; set; }
        public string V1HISP_DTVENCTO { get; set; }
        public string V1ENDO_NUMAPOL { get; set; }
        public string V1ENDO_NRENDOS { get; set; }
        public string AC_PARC { get; set; }

        public static R1311_00_DEMAIS_PARCELAS_DB_SELECT_1_Query1 Execute(R1311_00_DEMAIS_PARCELAS_DB_SELECT_1_Query1 r1311_00_DEMAIS_PARCELAS_DB_SELECT_1_Query1)
        {
            var ths = r1311_00_DEMAIS_PARCELAS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1311_00_DEMAIS_PARCELAS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1311_00_DEMAIS_PARCELAS_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1PARC_NUMAPOL = result[i++].Value?.ToString();
            dta.V1PARC_NRENDOS = result[i++].Value?.ToString();
            dta.V1PARC_NRPARCEL = result[i++].Value?.ToString();
            dta.V1PARC_NRTIT = result[i++].Value?.ToString();
            dta.V1PARC_VLPRMLIQ = result[i++].Value?.ToString();
            dta.V1PARC_QTDOCORR = result[i++].Value?.ToString();
            dta.V1PARC_SITUACAO = result[i++].Value?.ToString();
            dta.V1HISP_DTVENCTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}