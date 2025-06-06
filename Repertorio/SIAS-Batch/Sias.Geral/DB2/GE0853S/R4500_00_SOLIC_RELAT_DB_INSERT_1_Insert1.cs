using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0853S
{
    public class R4500_00_SOLIC_RELAT_DB_INSERT_1_Insert1 : QueryBasis<R4500_00_SOLIC_RELAT_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0RELATORIOS
            VALUES ( 'GE0853S' ,
            CURRENT DATE,
            'VA' ,
            :V0RELA-CODRELAT,
            0,
            :V0RELA-QTDPARATZ,
            CURRENT DATE,
            CURRENT DATE,
            :V0HISC-DTVENCTO,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            :V0HISC-NRPARCEL,
            :V0HISC-NRCERTIF,
            :V0HISC-NRTIT,
            0,
            0,
            0,
            0,
            ' ' ,
            ' ' ,
            0,
            0,
            ' ' ,
            0,
            0,
            ' ' ,
            '0' ,
            ' ' ,
            ' ' ,
            NULL,
            0,
            0,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0RELATORIOS VALUES ( 'GE0853S' , CURRENT DATE, 'VA' , {FieldThreatment(this.V0RELA_CODRELAT)}, 0, {FieldThreatment(this.V0RELA_QTDPARATZ)}, CURRENT DATE, CURRENT DATE, {FieldThreatment(this.V0HISC_DTVENCTO)}, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, {FieldThreatment(this.V0HISC_NRPARCEL)}, {FieldThreatment(this.V0HISC_NRCERTIF)}, {FieldThreatment(this.V0HISC_NRTIT)}, 0, 0, 0, 0, ' ' , ' ' , 0, 0, ' ' , 0, 0, ' ' , '0' , ' ' , ' ' , NULL, 0, 0, CURRENT TIMESTAMP)";

            return query;
        }
        public string V0RELA_CODRELAT { get; set; }
        public string V0RELA_QTDPARATZ { get; set; }
        public string V0HISC_DTVENCTO { get; set; }
        public string V0HISC_NRPARCEL { get; set; }
        public string V0HISC_NRCERTIF { get; set; }
        public string V0HISC_NRTIT { get; set; }

        public static void Execute(R4500_00_SOLIC_RELAT_DB_INSERT_1_Insert1 r4500_00_SOLIC_RELAT_DB_INSERT_1_Insert1)
        {
            var ths = r4500_00_SOLIC_RELAT_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R4500_00_SOLIC_RELAT_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}