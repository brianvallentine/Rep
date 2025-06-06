using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF2002B
{
    public class R3860_UPDATE_V0RCAP_DB_INSERT_1_Insert1 : QueryBasis<R3860_UPDATE_V0RCAP_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0RCAP
            (SELECT FONTE ,
            :V0RCAP-NRRCAP ,
            NRPROPOS ,
            NOME ,
            VLRCAP ,
            VALPRI ,
            DTCADAST ,
            DTMOVTO ,
            SITUACAO ,
            OPERACAO ,
            COD_EMPRESA ,
            CURRENT TIMESTAMP ,
            NUM_APOLICE ,
            NRENDOS ,
            NRPARCEL ,
            :V0RCAP-NRTIT ,
            CODPRODU ,
            AGECOBR ,
            RECUPERA ,
            VLACRESCIMO ,
            NRCERTIF
            FROM SEGUROS.V0RCAP
            WHERE FONTE = :V0RCOM-FONTE
            AND NRRCAP = :V0RCOM-NRRCAP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0RCAP (SELECT FONTE , {FieldThreatment(this.V0RCAP_NRRCAP)} , NRPROPOS , NOME , VLRCAP , VALPRI , DTCADAST , DTMOVTO , SITUACAO , OPERACAO , COD_EMPRESA , CURRENT TIMESTAMP , NUM_APOLICE , NRENDOS , NRPARCEL , {FieldThreatment(this.V0RCAP_NRTIT)} , CODPRODU , AGECOBR , RECUPERA , VLACRESCIMO , NRCERTIF FROM SEGUROS.V0RCAP WHERE FONTE = {FieldThreatment(this.V0RCOM_FONTE)} AND NRRCAP = {FieldThreatment(this.V0RCOM_NRRCAP)})";

            return query;
        }
        public string V0RCAP_NRRCAP { get; set; }
        public string V0RCAP_NRTIT { get; set; }
        public string V0RCOM_FONTE { get; set; }
        public string V0RCOM_NRRCAP { get; set; }

        public static void Execute(R3860_UPDATE_V0RCAP_DB_INSERT_1_Insert1 r3860_UPDATE_V0RCAP_DB_INSERT_1_Insert1)
        {
            var ths = r3860_UPDATE_V0RCAP_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3860_UPDATE_V0RCAP_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}