using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE0030B
{
    public class R0370_00_INSERT_ESTORNO_COMIS_DB_INSERT_1_Insert1 : QueryBasis<R0370_00_INSERT_ESTORNO_COMIS_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT INTO SEGUROS.V0COMISSAO
            VALUES (:V0COMI-NUM-APOL,
            :V0COMI-NRENDOS,
            :V0COMI-NRCERTIF,
            :V0COMI-DIGCERT,
            :V0COMI-IDTPSEGU,
            :V0COMI-NRPARCEL,
            :V0COMI-OPERACAO,
            :V0COMI-CODPDT,
            :V0COMI-RAMOFR,
            :V0COMI-MODALIFR,
            :V0COMI-OCORHIST,
            :V0COMI-FONTE,
            :V0COMI-CODCLIEN,
            :V0COMI-VLCOMIS,
            :V0COMI-DATCLO,
            :V0COMI-NUMREC,
            :V0COMI-VALBAS,
            :V0COMI-TIPCOM,
            :V0COMI-QTPARCEL,
            :V0COMI-PCCOMCOR,
            :V0COMI-PCDESCON,
            :V0COMI-CODSUBES,
            CURRENT TIME,
            NULL,
            :V0COMI-DATSEL,
            NULL,
            NULL,
            CURRENT TIMESTAMP,
            NULL,
            NULL,
            NULL)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0COMISSAO VALUES ({FieldThreatment(this.V0COMI_NUM_APOL)}, {FieldThreatment(this.V0COMI_NRENDOS)}, {FieldThreatment(this.V0COMI_NRCERTIF)}, {FieldThreatment(this.V0COMI_DIGCERT)}, {FieldThreatment(this.V0COMI_IDTPSEGU)}, {FieldThreatment(this.V0COMI_NRPARCEL)}, {FieldThreatment(this.V0COMI_OPERACAO)}, {FieldThreatment(this.V0COMI_CODPDT)}, {FieldThreatment(this.V0COMI_RAMOFR)}, {FieldThreatment(this.V0COMI_MODALIFR)}, {FieldThreatment(this.V0COMI_OCORHIST)}, {FieldThreatment(this.V0COMI_FONTE)}, {FieldThreatment(this.V0COMI_CODCLIEN)}, {FieldThreatment(this.V0COMI_VLCOMIS)}, {FieldThreatment(this.V0COMI_DATCLO)}, {FieldThreatment(this.V0COMI_NUMREC)}, {FieldThreatment(this.V0COMI_VALBAS)}, {FieldThreatment(this.V0COMI_TIPCOM)}, {FieldThreatment(this.V0COMI_QTPARCEL)}, {FieldThreatment(this.V0COMI_PCCOMCOR)}, {FieldThreatment(this.V0COMI_PCDESCON)}, {FieldThreatment(this.V0COMI_CODSUBES)}, CURRENT TIME, NULL, {FieldThreatment(this.V0COMI_DATSEL)}, NULL, NULL, CURRENT TIMESTAMP, NULL, NULL, NULL)";

            return query;
        }
        public string V0COMI_NUM_APOL { get; set; }
        public string V0COMI_NRENDOS { get; set; }
        public string V0COMI_NRCERTIF { get; set; }
        public string V0COMI_DIGCERT { get; set; }
        public string V0COMI_IDTPSEGU { get; set; }
        public string V0COMI_NRPARCEL { get; set; }
        public string V0COMI_OPERACAO { get; set; }
        public string V0COMI_CODPDT { get; set; }
        public string V0COMI_RAMOFR { get; set; }
        public string V0COMI_MODALIFR { get; set; }
        public string V0COMI_OCORHIST { get; set; }
        public string V0COMI_FONTE { get; set; }
        public string V0COMI_CODCLIEN { get; set; }
        public string V0COMI_VLCOMIS { get; set; }
        public string V0COMI_DATCLO { get; set; }
        public string V0COMI_NUMREC { get; set; }
        public string V0COMI_VALBAS { get; set; }
        public string V0COMI_TIPCOM { get; set; }
        public string V0COMI_QTPARCEL { get; set; }
        public string V0COMI_PCCOMCOR { get; set; }
        public string V0COMI_PCDESCON { get; set; }
        public string V0COMI_CODSUBES { get; set; }
        public string V0COMI_DATSEL { get; set; }

        public static void Execute(R0370_00_INSERT_ESTORNO_COMIS_DB_INSERT_1_Insert1 r0370_00_INSERT_ESTORNO_COMIS_DB_INSERT_1_Insert1)
        {
            var ths = r0370_00_INSERT_ESTORNO_COMIS_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0370_00_INSERT_ESTORNO_COMIS_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}